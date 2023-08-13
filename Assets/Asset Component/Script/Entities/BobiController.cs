using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] private bool isJump;
    
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
    }
    
    private void FixedUpdate()
    {
        PlayerJump();
    }
    
    private void Update()
    {
        PlayerCrouch();
    }

    #endregion

    #region Tsukuyomi Callbacks

    private void PlayerJump()
    {
        // Some Logic
    }
    
    private void PlayerCrouch()
    {
        // Some Logic
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
