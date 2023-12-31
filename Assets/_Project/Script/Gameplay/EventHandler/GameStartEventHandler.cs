using System;
using UnityEngine;

namespace BelumProduktif.Gameplay.EventHandler
{
    public class GameStartEventHandler : MonoBehaviour
    {
        public event Action OnGameStart;
        public void GameStartEvent() => OnGameStart?.Invoke();
    }
}