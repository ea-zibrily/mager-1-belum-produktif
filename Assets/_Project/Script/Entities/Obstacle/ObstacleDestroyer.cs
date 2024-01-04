using UnityEngine;

namespace BelumProduktif.Entities.Obstacle
{
    [AddComponentMenu("Tsukuyomi/Obstacle/ObstacleDestroyer")]
    public class ObstacleDestroyer : MonoBehaviour
    {
        #region Collider Callbacks
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Obstacle"))
            {
                return;
            }
            
            if (other.TryGetComponent<ObstacleController>(out var obstacle))
            {
                obstacle.DeactivateObstacle();
            }
        }
        
        #endregion
    }
}