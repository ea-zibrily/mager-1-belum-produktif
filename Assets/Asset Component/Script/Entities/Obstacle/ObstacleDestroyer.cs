using System;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    #region Collider Callbacks

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Ajurr");
            Destroy(other.gameObject);
        }
    }
    
    #endregion
}