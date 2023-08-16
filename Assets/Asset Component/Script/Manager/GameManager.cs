using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour, IObserver
{
    #region Variable

    [Header("Observer Subjects Component")]
    [SerializeField] private ObserverSubjects[] observerSubjects;
    
    [Header("Other Component")]
    [SerializeField] private GameObject gameOverPanel;
    public bool IsGamePlay { get; set; }
    
    [Header("Reference")]
    private ScoreController scoreController;
    private GameStartController gameStartController;
    
    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        gameStartController = GameObject.Find("GameStartController").GetComponent<GameStartController>();
    }

    private void OnEnable()
    {
        InitializeSubject();
    }
    
    private void OnDisable()
    {
        RemoveSubject();
    }

    private void Start()
    {
        IsGamePlay = false;
        gameOverPanel.SetActive(false);
    }
    
    #endregion

    #region Tsukuyomi Callbacks
    
    public void AddNotify(GameConditionEnum gameConditionEnum)
    {
        switch (gameConditionEnum)
        {
            case GameConditionEnum.Start:
                StartCoroutine(GameStart());
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
    
    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(0.4f);
        IsGamePlay = true;
    }
    
    private void GameOver()
    {
        FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Interact);
        gameOverPanel.SetActive(true);
        
        gameStartController.SetSecondPlay();
        scoreController.SaveHighScore();
        
        IsGamePlay = false;
        Time.timeScale = 0;
    }
    
    #endregion
}
