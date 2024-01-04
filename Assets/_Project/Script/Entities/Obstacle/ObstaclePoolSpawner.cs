using BelumProduktif.Managers;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

namespace BelumProduktif.Entities.Obstacle
{
    [AddComponentMenu("Tsukuyomi/Obstacle/ObstaclePoolSpawner")]
    public class ObstaclePoolSpawner : MonoBehaviour
    {
        #region Variable

        [Header("Generator")] 
        [SerializeField] private int defaultPoolCapacity;
        [SerializeField] private int maxPoolSize;
        [SerializeField] private float minTimeBetweenSpawn;
        [SerializeField] private float maxTimeBetweenSpawn;
        
        [Space]
        [SerializeField] private GameObject obstacleParent;
        [SerializeField] private ObstacleController[] obstaclePrefabs;
        [SerializeField] private Transform[] obstacleSpawnPoint;
    
        private ObjectPool<ObstacleController> obstaclePool;
        
        private int poolCount;
        private int currentPoolIndex;
        private float currentTimeSpawn;
        private float currentTimeBetweenSpawn;

        #endregion

        #region MonoBehaviour Callbacks
        
        private void Start()
        {
            obstaclePool = new ObjectPool<ObstacleController>(CreateObstacle, OnGetFromPool, 
                OnReleaseToPool, OnDestroyPooledObject, true, defaultPoolCapacity, maxPoolSize);
            
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
        
        #region Object Pooling Callbacks
        
        // invoked when creating an item to populate the object pool
        private ObstacleController CreateObstacle()
        {
            var randomObstacle = Random.Range(0, obstaclePrefabs.Length - 1);
            if (currentPoolIndex == randomObstacle)
            {
                if (poolCount < 1)
                {
                    poolCount++;
                }
                else
                {
                    Debug.LogWarning("instantiate 2 same object!");
                    while (randomObstacle == currentPoolIndex)
                    {
                        var repeatRandom = Random.Range(0, obstaclePrefabs.Length - 1);
                        randomObstacle = repeatRandom;
                        Debug.Log($"iterate random value: {randomObstacle}");
                    }
                    
                    Debug.LogWarning($"randomize again done lur: {randomObstacle}");
                    poolCount = 0;
                }
            }
            
            currentPoolIndex = randomObstacle;
            var obstacleObject = Instantiate(obstaclePrefabs[randomObstacle], obstacleParent.transform, false);
            obstacleObject.ObjectPool = obstaclePool;
            return obstacleObject;
        }
        
        // invoked when retrieving the next item from the object pool
        private void OnGetFromPool(ObstacleController pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
        }
        
        // invoked when returning an item to the object pool
        private void OnReleaseToPool(ObstacleController pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }
        
        // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
        private void OnDestroyPooledObject(ObstacleController pooledObject)
        {
            Destroy(pooledObject.gameObject);
        }
        
        #endregion
        
        #region Tsukuyomi Callbacks
        
        private void InitializeTimeSpawn()
        {
            currentTimeSpawn = 0f;
            currentTimeBetweenSpawn = minTimeBetweenSpawn;
        }
        
        private void LoopGenerate()
        {
            currentTimeSpawn += Time.deltaTime;
            var randomTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        
            if (currentTimeSpawn >= currentTimeBetweenSpawn)
            {
                GenerateObstacle();
                currentTimeSpawn = 0f;
                currentTimeBetweenSpawn = randomTimeBetweenSpawn;
            }
        }
        
        private void GenerateObstacle()
        {
            var randomSpawnPoint = Random.Range(0, obstacleSpawnPoint.Length - 1);
            
            var obstacleObject = obstaclePool.Get();
            obstacleObject.transform.position = obstacleSpawnPoint[randomSpawnPoint].position;
        }
    
        #endregion
        
    }
}