using System;
using UnityEngine;

public class GameStartEventHandler : MonoBehaviour
{
    public event Action OnGameStart;
    public void GameStartEvent() => OnGameStart?.Invoke();
}