using System;
using UnityEngine;

public class PlayManager : ObserverSubjects
{
    #region Variable

    [Header("Play Component")]
    [SerializeField] private GameObject playPanel;
    
    [Header("Reference")]
    private PlayEventHandler playEventHandler;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        playEventHandler = GameObject.Find("PlayPanel").GetComponent<PlayEventHandler>();
    }

    private void OnEnable()
    {
        playEventHandler.OnGameStart += GameStart;
    }
    
    private void OnDisable()
    {
        playEventHandler.OnGameStart -= GameStart;
    }
    
    #endregion
    
    #region Tsukuyomi Callbacks

    private void GameStart()
    {
        NotifyObservers(GameConditionEnum.Start);
        playPanel.SetActive(false);
    }
    public void StartGamePlay()
    {
        playPanel.GetComponent<Animator>().SetBool("IsPlay", true);
    }

    #endregion

}