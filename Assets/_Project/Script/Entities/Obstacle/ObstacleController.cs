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
        private float _currentObstacleMoveSpeed;

        private ObjectPool<ObstacleController> _objectPool;
        public ObjectPool<ObstacleController> ObjectPool { set => _objectPool = value; }
    
        [Header("Reference")]
        private Rigidbody2D _obstacleRb;
        private ScoreController _scoreController;
    
        #endregion
    
        #region MonoBehaviour Callbacks

        private void Awake()
        {
            _obstacleRb = GetComponent<Rigidbody2D>();
            _scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        }

        private void Start()
        {
            gameObject.name = obstacleData.ObstacleName;
            _currentObstacleMoveSpeed = obstacleData.ObstacleMoveSpeed;
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
            _currentObstacleMoveSpeed = obstacleData.ObstacleMoveSpeed;
            _obstacleRb.velocity = Vector2.zero;
            transform.position = Vector3.zero;
            
            // Release obstacle back to the pool
            _objectPool.Release(this);
        }
        
        private void ObstacleMovement() => _obstacleRb.velocity = Vector2.left * _currentObstacleMoveSpeed;
        
        private void StopObstacleMovement() => _obstacleRb.velocity = Vector2.zero;
        
        private void IncreaseObstacleMoveSpeed()
        {
            _currentObstacleMoveSpeed += _scoreController.MultiplierTime; 
            if (obstacleData.ObstacleMoveSpeed > obstacleData.ObstacleMaxMoveSpeed)
            {
                _currentObstacleMoveSpeed = obstacleData.ObstacleMaxMoveSpeed;
            }
        }
        
        #endregion
    }
}