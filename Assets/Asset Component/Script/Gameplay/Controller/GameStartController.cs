using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GameStartController : ObserverSubjects
{
    #region Variable
    
    [Header("Play Component")]
    [SerializeField] private GameObject gameStartPanel;
    public string FirstPlay { get; private set; } = "FirstPlay";
    
    [Header("Reference")]
    private GameStartEventHandler gameStartEventHandler;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        gameStartEventHandler = GameObject.Find("PlayPanel").GetComponent<GameStartEventHandler>();
    }
    
    private void OnEnable()
    {
        gameStartEventHandler.OnGameStart += GameStart;
    }
    
    private void OnDisable()
    {
        gameStartEventHandler.OnGameStart -= GameStart;
    }
    
    private void Start()
    {
        InitializeStartPrefs();
    }

    private void Update()
    {
        CheckFirstPlay();
    }
    
    #endregion
    
    #region Tsukuyomi Callbacks

    private void InitializeStartPrefs()
    {
        if (!PlayerPrefs.HasKey(FirstPlay))
        {
            PlayerPrefs.SetString(FirstPlay, "true");
        }
    }
    private void CheckFirstPlay()
    {
        var firstPlay = PlayerPrefs.GetString(FirstPlay);
        if (firstPlay == "false")
        {
            gameStartPanel.SetActive(false);
        }
    }
    public void SetSecondPlay()
    {
        var firstPlay = PlayerPrefs.GetString(FirstPlay);
        if (firstPlay != "true")
        {
            return;
        }
        PlayerPrefs.SetString(FirstPlay, "false");
    }
    private void GameStart()
    {
        NotifyObservers(GameConditionEnum.Start);
        gameStartPanel.SetActive(false);
    }
    public void StartGamePlay()
    {
        FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Paper);
        gameStartPanel.GetComponent<Animator>().SetBool("IsPlay", true);
    }
    
    #endregion

}