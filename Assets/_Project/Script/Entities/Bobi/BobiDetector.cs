using BelumProduktif.DesignPattern.Observer;
using BelumProduktif.Enum;
using BelumProduktif.Manager;
using UnityEngine;

namespace BelumProduktif.Entities.Bobi
{
    public class BobiDetector : ObserverSubjects
    {
        #region Collider Callbacks

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacle"))
            {
                FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Interact);
                NotifyObservers(GameConditionEnum.Over);
            }
        }

        #endregion
    }
}
