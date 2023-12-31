using UnityEngine;

namespace BelumProduktif.Entities.Obstacle
{
    public class ObstacleDestroyer : MonoBehaviour
    {
        #region Collider Callbacks

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                Destroy(other.gameObject);
            }
        }
    
        #endregion
    }
}