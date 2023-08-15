using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleController : MonoBehaviour
{
    #region Variable
    
    [Header("Obstacle Component")]
    [SerializeField] private ObstacleData obstacleData;
    private float currentObstacleMoveSpeed;
    
    [Header("Reference")]
    private Rigidbody2D obstacleRb;
    private ScoreController scoreController;
    
    #endregion
    
    #region MonoBehaviour Callbacks

    private void Awake()
    {
        obstacleRb = GetComponent<Rigidbody2D>();
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }
    
    private void Start()
    {
        gameObject.name = obstacleData.ObstacleName;
        currentObstacleMoveSpeed = obstacleData.ObstacleMoveSpeed;
    }
    
    private void Update()
    {
        ObstacleMovement();
    }
    
    #endregion

    #region Tsukuyomi Callbacks
    
    private void ObstacleMovement()
    {
        IncreaseObstacleMoveSpeed();
        obstacleRb.velocity = Vector2.left * currentObstacleMoveSpeed;
    }
    
    private void IncreaseObstacleMoveSpeed()
    {
        currentObstacleMoveSpeed += scoreController.MultiplierTime; 
        if (obstacleData.ObstacleMoveSpeed > obstacleData.ObstacleMaxMoveSpeed)
        {
            currentObstacleMoveSpeed = obstacleData.ObstacleMaxMoveSpeed;
        }
    }

    #endregion
}