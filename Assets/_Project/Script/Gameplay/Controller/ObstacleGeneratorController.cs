using BelumProduktif.Manager;
using UnityEngine;

namespace BelumProduktif.Gameplay.Controller
{
    public class ObstacleGeneratorController : MonoBehaviour
    {
        #region Variable

        [Header("Generator Component")]
        [SerializeField] private float minTimeBetweenSpawn;
        [SerializeField] private float maxTimeBetweenSpawn;
        [SerializeField] private GameObject[] obstaclePrefabs;
        [SerializeField] private Transform[] obstacleSpawnPoint;
    
        private float currentTimeSpawn;
        private float currentTimeBetweenSpawn;
    
        [Header("Reference")]
        private GameManager gameManager;
    
        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        private void Start()
        {
            currentTimeBetweenSpawn = minTimeBetweenSpawn;
        }

        private void Update()
        {
            if (!gameManager.IsGamePlay)
            {
                return;
            }
            LoopGenerate();
        }
    
        #endregion

        #region Tsukuyomi Callbacks

        private void LoopGenerate()
        {
            currentTimeSpawn += Time.deltaTime;
            var randomTimeBetweenSpawn = UnityEngine.Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
        
            if (currentTimeSpawn >= currentTimeBetweenSpawn)
            {
                GenerateObstacle();
                currentTimeSpawn = 0f;
                currentTimeBetweenSpawn = randomTimeBetweenSpawn;
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