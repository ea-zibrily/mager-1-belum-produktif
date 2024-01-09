using System;
using BelumProduktif.Managers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using BelumProduktif.Enum;

namespace BelumProduktif.Gameplay.Controller
{
    [RequireComponent(typeof(PlayerInput))]
    [AddComponentMenu("Tsukuyomi/Controller/PauseController")]
    public class PauseController : MonoBehaviour
    {
        #region Variable
        
        [Header("Reference")]
        [SerializeField] private GameObject pausePanel;
        
        private Button _pauseButton;
        private bool _isPausePanelOpen;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            _pauseButton = pausePanel.GetComponentInChildren<Button>();
        }

        private void Start()
        {
            pausePanel.SetActive(false);
            _isPausePanelOpen = false;
            _pauseButton.onClick.AddListener(ClosePausePanel);
        }
    
        #endregion

        #region Tsukuyomi Callbacks

        public void PauseGame(InputAction.CallbackContext button)
        {
            if (!GameManager.Instance.IsGameStart)
            {
                return;
            }

            if (!button.started)
            {
                return;
            }
            
            FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Interact);
            if (!_isPausePanelOpen)
            {
                OpenPausePanel();
            }
            else
            {
                ClosePausePanel();
            }
        }

        private void OpenPausePanel()
        {
            pausePanel.SetActive(true);
            _isPausePanelOpen = true;
            Time.timeScale = 0;
        }
    
        private void ClosePausePanel()
        {
            pausePanel.SetActive(false);
            _isPausePanelOpen = false;
            Time.timeScale = 1;
        }
    
        #endregion
    }
}