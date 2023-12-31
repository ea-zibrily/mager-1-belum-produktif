using BelumProduktif.Enum;
using BelumProduktif.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BelumProduktif.Gameplay.Controller
{
    [RequireComponent(typeof(PlayerInput))]
    public class PauseController : MonoBehaviour
    {
        #region Variable
    
        [SerializeField] private GameObject pausePanel;
        private bool isPausePanelOpen;
        private GameManager gameManager;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        private void Start()
        {
            pausePanel.SetActive(false);
            isPausePanelOpen = false;
        }
    
        #endregion

        #region Tsukuyomi Callbacks

        public void PauseGame(InputAction.CallbackContext button)
        {
            if (!gameManager.IsGamePlay)
            {
                return;
            }
        
            if (button.started)
            {
                FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Interact);
                if (!isPausePanelOpen)
                {
                    OpenPausePanel();
                }
                else
                {
                    ClosePausePanel();
                }
            }
        }

        private void OpenPausePanel()
        {
            pausePanel.SetActive(true);
            isPausePanelOpen = true;
            Time.timeScale = 0;
        }
    
        private void ClosePausePanel()
        {
            pausePanel.SetActive(false);
            isPausePanelOpen = false;
            Time.timeScale = 1;
        }
    
        #endregion
    }
}