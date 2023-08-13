using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

#region Require Component

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

#endregion
public class BobiController : MonoBehaviour
{
    #region Variable

    [Header("Controller Component")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private ColliderData[] colliderData;
    private bool isJump;
    
    [Header("Ground Checker Component")]
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float groundCheckerRadius;
    public LayerMask groundLayer;
    
    [Header("Reference")] 
    private Rigidbody2D myRb;
    private BoxCollider2D myBc;
    private Animator myAnim;
    
    #endregion

    #region Struct

    [Serializable]
    public struct ColliderData
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
    }

    private void Start()
    {
        gameObject.name = playerData.PlayerName;
        SetOffSizeCollider(colliderData[0].offset, colliderData[0].size);
    }
    

    #endregion

    #region Tsukuyomi Callbacks
    
    public void PlayerJump(InputAction.CallbackContext button)
    {
        if (button.performed && IsGround())
        {
            myRb.AddForce(Vector2.up * playerData.PlayerJumpForce, ForceMode2D.Impulse);
        }
        else if (button.canceled && !IsGround())
        {
            myRb.velocity = new Vector2(myRb.velocity.x, myRb.velocity.y * 0.5f);
        }
    }
    
    public void PlayerCrouch(InputAction.CallbackContext button)
    {
        if (!IsGround())
        {
            return;
        }
        
        if (button.started)
        {
            myAnim.SetBool("IsCrouch", true);
            SetOffSizeCollider(colliderData[1].offset, colliderData[1].size);
        }
        else if (button.canceled)
        {
            myAnim.SetBool("IsCrouch", false);
            SetOffSizeCollider(colliderData[0].offset, colliderData[0].size);
        }
    }
    
    private void SetOffSizeCollider(Vector2 offset, Vector2 size)
    {
        myBc.offset = offset;
        myBc.size = size;
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
