using System.Collections;
using BelumProduktif.DesignPattern.Singleton;
using BelumProduktif.Enum;
using BelumProduktif.Gameplay.Controller;
using BelumProduktif.Helpers;
using KevinCastejon.MoreAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace BelumProduktif.Managers
{
    [AddComponentMenu("Tsukuyomi/Managers/GameManager")]
    public class GameManager : MonoSingleton<GameManager>
    {
        #region Variable
        
        [Header("Interface")]
        [SerializeField] private GameObject gameOverPanel;
        private Button _restartButton;

        [field: SerializeField, ReadOnlyOnPlay] public bool IsGameStart { get; private set; }
        
        private bool _isHavePlayed;
        public bool IsHavePlayed
        {
            get
            {
                if (PlayerPrefs.HasKey(HAVE_PLAYED_KEY))
                {
                    var havePlayed = PlayerPrefs.GetString(HAVE_PLAYED_KEY) is "True";
                    _isHavePlayed = havePlayed;
                }
                return _isHavePlayed;
            }
            private set => _isHavePlayed = value;
        }

        private const string HAVE_PLAYED_KEY = "Played";
        
        #region Event
        private delegate void GameStart();
        private event GameStart OnGameStart;
        
        private delegate IEnumerator GameOver();
        private event GameOver OnGameOver;
        #endregion

        [Header("Reference")] 
        private ScoreController _scoreController;

        #endregion

        #region MonoBehaviour Callbacks

        protected override void Awake()
        { 
            base.Awake();
            _restartButton = gameOverPanel.GetComponentInChildren<Button>();
            _scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        }

        private void OnEnable()
        {
            // Subscribe Event
            OnGameStart += StartGame;
            OnGameOver += EndGame;
        }

        private void OnDisable()
        {
            // Unsubscribe Event
            OnGameStart -= StartGame;
            OnGameOver -= EndGame;
        }

        private void Start()
        {
            gameOverPanel.SetActive(false);
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void OnApplicationQuit()
        {
            ExitGame();
        }

        #endregion
        
        #region Tsukuyomi Callbacks
        
        // Call Event
        public void GameStartEvent() => OnGameStart?.Invoke();
        public void GameOverEvent() => StartCoroutine(OnGameOver?.Invoke());

        private void StartGame()
        {
            IsGameStart = true;
            IsHavePlayed = true;
            PrefsHelpers.InitStringPrefs(HAVE_PLAYED_KEY, IsHavePlayed.ToString());
            
            //--- Internal Saver
            // SaveHavePlayed(IsHavePlayed.ToString());
        }
        
        private void RestartGame()
        {
            FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Click);
            Time.timeScale = 1;
            FeedbackManager.Instance.CallDirectionalIn();
        }
        
        private IEnumerator EndGame()
        {
            FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Interact);
            IsGameStart = false;
            FeedbackManager.Instance.CallImpulse();
            
            yield return new WaitForSeconds(0.25f);
            gameOverPanel.SetActive(true);
            _scoreController.SaveHighScore();
            
            Time.timeScale = 0;
        }
        
        private void ExitGame()
        { 
            IsGameStart = false;
            IsHavePlayed = false;
            PlayerPrefs.DeleteAll();
        }

        private void SaveHavePlayed(string value)
        {
            if (!PlayerPrefs.HasKey(HAVE_PLAYED_KEY))
            {
                PlayerPrefs.SetString(HAVE_PLAYED_KEY, value);
            }
        }
        
        #endregion
    }
}
