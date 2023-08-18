using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
