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
        
        private float _currentJumpTime;
        private bool _isJump;
        private bool _isCrouch;
    
        [Header("Ground Checker")]
        [SerializeField] private Transform groundChecker;
        [SerializeField] [ReadOnlyOnPlay] private float groundCheckerRadius;
        [SerializeField] private LayerMask groundLayer;
        
        [Header("Reference")] 
        private Rigidbody2D _myRb;
        private BoxCollider2D _myBc;
        private BoxCollider2D _myDetectorBc;
        private Animator _myAnim;
    
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
            _myRb = GetComponent<Rigidbody2D>();
            _myBc = GetComponent<BoxCollider2D>();
            _myAnim = GetComponentInChildren<Animator>();
            
            _myDetectorBc = transform.GetChild(2).GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            gameObject.name = playerData.PlayerName;
            SetOffSizeCollider(colliderData[0].offset, colliderData[0].size);
            
            _isJump = false;
            _isCrouch = false;
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
        
            if (button.performed && IsGround() && !_isCrouch)
            {
                _myRb.AddForce(Vector2.up * playerData.PlayerJumpForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Jump);
                _isJump = true;
            }
        }

        public void PlayerCrouch(InputAction.CallbackContext button)
        {
            if (!GameManager.Instance.IsGameStart)
            {
                return;
            }

            if (_isJump)
            {
                return;
            }
        
            if (button.started)
            {
                _myAnim.SetBool("IsCrouch", true);
                FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Crouch);
                SetOffSizeCollider(colliderData[1].offset, colliderData[1].size);
                _isCrouch = true;
            }
            else if (button.canceled)
            {
                _myAnim.SetBool("IsCrouch", false);
                SetOffSizeCollider(colliderData[0].offset, colliderData[0].size);
                _isCrouch = false;
            }
        }

        private void PlayerDown()
        {
            if (!_isJump)
            {
                return;
            }
            
            _currentJumpTime += Time.deltaTime;
            if (_currentJumpTime >= playerData.PlayerMaxJumpTime)
            {
                _currentJumpTime = 0f;
                _isJump = false;
            }
        }
        
        private void SetOffSizeCollider(Vector2 offset, Vector2 size)
        {
            _myBc.offset = offset;
            _myBc.size = size;
        
            _myDetectorBc.offset = offset;
            _myDetectorBc.size = size;
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
