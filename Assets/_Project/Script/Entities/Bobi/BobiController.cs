using System;
using BelumProduktif.Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using KevinCastejon.MoreAttributes;
using BelumProduktif.Enum;
using BelumProduktif.ScriptableObject;

namespace BelumProduktif.Entities.Bobi
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [AddComponentMenu("Tsukuyomi/Bobi/BobiController")]
    public class BobiController : MonoBehaviour
    {
        #region Variable

        [Header("Player Data")]
        [SerializeField] private PlayerData playerData;
        [SerializeField] private ColliderData[] colliderData;
        
        private float currentJumpTime;
        private bool isJump;
        private bool isCrouch;
    
        [Header("Ground Checker")]
        [SerializeField] private Transform groundChecker;
        [SerializeField] [ReadOnlyOnPlay] private float groundCheckerRadius;
        public LayerMask groundLayer;
        
        [Header("Reference")] 
        private Rigidbody2D myRb;
        private BoxCollider2D myBc;
        private BoxCollider2D myDetectorBc;
        private Animator myAnim;
    
        #endregion

        #region Struct

        [Serializable]
        private struct ColliderData
        {
            public string name;
            public Vector2 offset;
            public Vector2 size;
        }

        #endregion
    
        #region MonoBehaviour Callbacks
        
        private void Awake()
        {
            myRb = GetComponent<Rigidbody2D>();
            myBc = GetComponent<BoxCollider2D>();
            myAnim = GetComponentInChildren<Animator>();
            
            myDetectorBc = transform.GetChild(2).GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            gameObject.name = playerData.PlayerName;
            SetOffSizeCollider(colliderData[0].offset, colliderData[0].size);
            
            isJump = false;
            isCrouch = false;
        }
        
        private void Update()
        {
            PlayerDown(); 
        }

        #endregion

        #region Tsukuyomi Callbacks
        
        public void PlayerJump(InputAction.CallbackContext button)
        {
            if (!GameManager.Instance.IsGameStart)
            {
                return;
            }
        
            if (button.performed && IsGround() && !isCrouch)
            {
                myRb.AddForce(Vector2.up * playerData.PlayerJumpForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Jump);
                isJump = true;
            }
        }

        public void PlayerCrouch(InputAction.CallbackContext button)
        {
            if (!GameManager.Instance.IsGameStart)
            {
                return;
            }

            if (isJump)
            {
                return;
            }
        
            if (button.started)
            {
                myAnim.SetBool("IsCrouch", true);
                FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Crouch);
                SetOffSizeCollider(colliderData[1].offset, colliderData[1].size);
                isCrouch = true;
            }
            else if (button.canceled)
            {
                myAnim.SetBool("IsCrouch", false);
                SetOffSizeCollider(colliderData[0].offset, colliderData[0].size);
                isCrouch = false;
            }
        }

        private void PlayerDown()
        {
            if (!isJump)
            {
                return;
            }
            
            currentJumpTime += Time.deltaTime;
            if (currentJumpTime >= playerData.PlayerMaxJumpTime)
            {
                currentJumpTime = 0f;
                isJump = false;
            }
        }
        
        private void SetOffSizeCollider(Vector2 offset, Vector2 size)
        {
            myBc.offset = offset;
            myBc.size = size;
        
            myDetectorBc.offset = offset;
            myDetectorBc.size = size;
        }
        
        private bool IsGround()
        {
            return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
        }
    
        #endregion

    }
}
