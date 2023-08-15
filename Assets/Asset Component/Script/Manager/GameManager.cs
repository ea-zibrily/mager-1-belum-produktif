using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IObserver
{
    #region Variable

    [Header("Observer Subjects Component")]
    [SerializeField] private ObserverSubjects[] observerSubjects;
    
    [Header("Game Condition Component")]
    [SerializeField] private GameObject gameStartPanel;
    [SerializeField] private GameObject gameOverPanel;
    public bool IsGamePlay { get; private set; }
    
    [Header("Reference")]
    private ScoreController scoreController;
    
    #endregion


    #region MonoBehaviour Callbacks

    private void Awake()
    {
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }

    private void OnEnable()
    {
        InitializeSubject();
    }
    
    private void OnDisable()
    {
        RemoveSubject();
    }

    #endregion

    #region Tsukuyomi Callbacks
    
    public void AddNotify(GameConditionEnum gameConditionEnum)
    {
        switch (gameConditionEnum)
        {
            case GameConditionEnum.Start:
                GameStart();
                break;
            case GameConditionEnum.Over:
                GameOver();
                break;
            default:
                Debug.Log("Game Condition Not Found");
                break;
        }
    }
    
    private void InitializeSubject()
    {
        for (int i = 0; i < observerSubjects.Length; i++)
        {
            observerSubjects[i].AddObserver(this);
        }
    }
    
    private void RemoveSubject()
    {
        for (int i = 0; i < observerSubjects.Length; i++)
        {
            observerSubjects[i].RemoveObserver(this);
        }
    }
    
    private void GameStart()
    {
        IsGamePlay = true;
    }
    
    private void GameOver()
    {
        FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Interact);
        gameOverPanel.SetActive(true);
        scoreController.SaveHighScore();
        IsGamePlay = false;
        Time.timeScale = 0;
    }

    #endregion
}
