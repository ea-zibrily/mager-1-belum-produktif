using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ArenaController : MonoBehaviour
{
    #region Variable

    [Header("Way Component")] 
    [SerializeField] private float wayMoveSpeed;
    [SerializeField] private float maxWayMoveSpeed;
    
    private Transform wayStartPosition;
    private Transform wayEndPosition;

    [Header("Reference")]
    private ScoreController scoreController;
    private GameManager gameManager;
    
    #endregion
    
    #region MonoBehaviour Callbacks

    private void Awake()
    {
        wayStartPosition = GameObject.Find("WayPosition_1").transform;
        wayEndPosition = GameObject.Find("WayPosition_2").transform;
        
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    private void Update()
    {
        if (!gameManager.IsGamePlay)
        {
            return;
        }
        WayMovement();
    }
    
    #endregion
    
    #region Tsukuyomi Callbacks
    
    private void WayMovement()
    {
        IncreaseWayMoveSpeed();
        transform.position = new Vector2(transform.position.x - wayMoveSpeed * Time.deltaTime, transform.position.y);
        if(transform.position.x <= wayEndPosition.transform.position.x)
        {
            transform.position = wayStartPosition.transform.position;
        }
    }

    private void IncreaseWayMoveSpeed()
    {
        wayMoveSpeed += scoreController.MultiplierTime;
        if (wayMoveSpeed > maxWayMoveSpeed)
        {
            wayMoveSpeed = maxWayMoveSpeed;
        }
    }
    
    #endregion

}
