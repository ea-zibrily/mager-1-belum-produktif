using BelumProduktif.DesignPattern.Observer;
using BelumProduktif.Enum;
using BelumProduktif.Gameplay.EventHandler;
using UnityEngine;
using UnityEngine.UI;

namespace BelumProduktif.Managers
{
    [AddComponentMenu("Tsukuyomi/Managers/MainMenuManager")]
    public class MainMenuManager : ObserverSubjects
    {
        #region Variable
        
        [Header("Reference")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject scorePanel;

        private Button mainMenuButton;
        private GameStartEventHandler gameStartEventHandler;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            var mainMenuObject = GameObject.Find("MainMenuPanel").gameObject;
            gameStartEventHandler = mainMenuObject.GetComponent<GameStartEventHandler>();
            mainMenuButton = mainMenuObject.GetComponentInChildren<Button>();
        }
    
        private void OnEnable()
        {
            gameStartEventHandler.OnGameStart += StartGame;
            gameStartEventHandler.OnActivateScorePanel += ActivateScorePanel;
        }
    
        private void OnDisable()
        {
            gameStartEventHandler.OnGameStart -= StartGame;
            gameStartEventHandler.OnActivateScorePanel -= ActivateScorePanel;
        }
        
        private void Start()
        {
            InitializeMainMenu();
            mainMenuButton.onClick.AddListener(OpenGameArena);
        }
        
        #endregion
        
        #region Tsukuyomi Callbacks
        
        private void InitializeMainMenu()
        {
            if (GameManager.Instance.IsHavePlayed)
            {
                mainMenuPanel.SetActive(false);
                scorePanel.SetActive(true);
            }
            else
            {
                mainMenuPanel.SetActive(true);
                scorePanel.SetActive(false);
            }
        }
        
        private void OpenGameArena()
        {
            FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Click);
            mainMenuPanel.GetComponent<Animator>().SetBool("IsPlay", true);
            FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Paper);
        }
        
        private void StartGame()
        {
            GameManager.Instance.GameStartEvent();
            mainMenuPanel.SetActive(false);
        }
        
        private void ActivateScorePanel() => scorePanel.SetActive(true);

        #endregion

    }
}