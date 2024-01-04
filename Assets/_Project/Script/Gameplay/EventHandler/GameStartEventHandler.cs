using System;
using UnityEngine;

namespace BelumProduktif.Gameplay.EventHandler
{
    public class GameStartEventHandler : MonoBehaviour
    {
        public event Action OnGameStart;
        public event Action OnActivateScorePanel;
        
        public void GameStartEvent() => OnGameStart?.Invoke();
        public void ActivateScorePanelEvent() => OnActivateScorePanel?.Invoke();
    }
}