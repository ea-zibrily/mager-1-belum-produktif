using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PauseController : MonoBehaviour
{
    #region Variable
    
    [SerializeField] private GameObject pausePanel;
    private bool isPausePanelOpen;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        pausePanel.SetActive(false);
        isPausePanelOpen = false;
    }
    
    #endregion

    #region Tsukuyomi Callbacks

    public void PauseGame(InputAction.CallbackContext button)
    {
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