using BelumProduktif.Managers;
using UnityEngine;

namespace BelumProduktif.Entities.Obstacle
{
    [AddComponentMenu("Tsukuyomi/Obstacle/ObstacleNormalSpawner")]
    public class ObstacleNormalSpawner : MonoBehaviour
    {
        #region Variable

        [Header("Generator")]
        [SerializeField] private float minTimeBetweenSpawn;
        [SerializeField] private float maxTimeBetweenSpawn;
        [SerializeField] private GameObject[] obstaclePrefabs;
        [SerializeField] private Transform[] obstacleSpawnPoint;
    
        private float _currentTimeSpawn;
        private float _currentTimeBetweenSpawn;
    
        #endregion

        #region MonoBehaviour Callbacks
        
        private void Start()
        {
            InitializeTimeSpawn();
        }

        private void Update()
        {
            if (!GameManager.Instance.IsGameStart)
            {
                return;
            }
            
            LoopGenerate();
        }
    
        #endregion

        #region Tsukuyomi Callbacks

        private void InitializeTimeSpawn()
        {
            _currentTimeSpawn = 0f;
            _currentTimeBetweenSpawn = minTimeBetweenSpawn;
        }
        
        private void LoopGenerate()
        {
            _currentTimeSpawn += Time.deltaTime;
            var randomTimeBetweenSpawn = UnityEngine.Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        
            if (_currentTimeSpawn >= _currentTimeBetweenSpawn)
            {
                GenerateObstacle();
                _currentTimeSpawn = 0f;
                _currentTimeBetweenSpawn = randomTimeBetweenSpawn;
            }
        }
      
        private void GenerateObstacle()
        {
            var randomObstacle = UnityEngine.Random.Range(0, obstaclePrefabs.Length - 1);
            var randomSpawnPoint = UnityEngine.Random.Range(0, obstacleSpawnPoint.Length - 1);
        
            var spawnedObstacle = Instantiate(obstaclePrefabs[randomObstacle], obstacleSpawnPoint[randomSpawnPoint].position,
                Quaternion.identity);
        }
    
        #endregion
    
    
    }
}