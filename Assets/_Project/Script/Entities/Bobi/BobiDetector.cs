using System;
using BelumProduktif.Managers;
using UnityEngine;

namespace BelumProduktif.Entities.Bobi
{
    [AddComponentMenu("Tsukuyomi/Bobi/BobiDetector")]
    public class BobiDetector : MonoBehaviour
    {
        #region Collider Callbacks

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                GameManager.Instance.GameOverEvent();
            }
        }

        #endregion
    }
}
