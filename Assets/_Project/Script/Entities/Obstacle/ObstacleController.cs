using BelumProduktif.Managers;
using UnityEngine;
using UnityEngine.Pool;
using BelumProduktif.ScriptableObject;
using BelumProduktif.Gameplay.Controller;

namespace BelumProduktif.Entities.Obstacle
{
    [RequireComponent(typeof(Rigidbody2D))]
    [AddComponentMenu("Tsukuyomi/Obstacle/ObstacleController")]
    public class ObstacleController : MonoBehaviour
    {
        #region Variable
    
        [Header("Obstacle")]
        [SerializeField] private ObstacleData obstacleData;
        private float currentObstacleMoveSpeed;

        private ObjectPool<ObstacleController> objectPool;
        public ObjectPool<ObstacleController> ObjectPool { set => objectPool = value; }
    
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
            if (!GameManager.Instance.IsGameStart)
            {
                StopObstacleMovement();
                return;
            }
            
            IncreaseObstacleMoveSpeed();
            ObstacleMovement();
        }
    
        #endregion

        #region Tsukuyomi Callbacks
        
        public void DeactivateObstacle()
        {
            // Reset all obstacle data
            currentObstacleMoveSpeed = obstacleData.ObstacleMoveSpeed;
            obstacleRb.velocity = Vector2.zero;
            transform.position = Vector3.zero;
            
            // Release obstacle back to the pool
            objectPool.Release(this);
        }
        
        private void ObstacleMovement() => obstacleRb.velocity = Vector2.left * currentObstacleMoveSpeed;
        
        private void StopObstacleMovement() => obstacleRb.velocity = Vector2.zero;
        
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
}