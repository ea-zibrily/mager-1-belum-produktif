using System;
using UnityEngine;

public class PlayEventHandler : MonoBehaviour
{
    public event Action OnGameStart;
    public void GameStartEvent() => OnGameStart?.Invoke();
    public void PlaySoundEffect() => FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Interact);
}