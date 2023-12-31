using UnityEngine;
using TMPro;
using BelumProduktif.Manager;

namespace BelumProduktif.Gameplay.Controller
{
    public class ScoreController : MonoBehaviour
    {
        #region Variable
    
        [Header("Score Component")] 
        [SerializeField] private float currentScore;
        [SerializeField] private float multiplierScore;
        [SerializeField] private TextMeshProUGUI currentScoreTextUI;
        [SerializeField] private TextMeshProUGUI highScoreTextUI;
        
        public float MultiplierTime { get; private set; }
    
        // Constant n Static Variable
        public const string HIGH_SCORE_KEY = "HighScore";
        private const string TEXT_SCORE_FORMAT = "000000";
    
        [Header("Reference")]
        private GameManager gameManager;

        #endregion

        #region MonoBehaviour Callbacks

        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        private void Start()
        {
            InitializeScorePrefs();
        
            currentScore = 0f;
            currentScoreTextUI.text = currentScore.ToString(TEXT_SCORE_FORMAT);
            highScoreTextUI.text = PlayerPrefs.GetFloat(HIGH_SCORE_KEY).ToString(TEXT_SCORE_FORMAT);
        }

        private void Update()
        {
            if (!gameManager.IsGamePlay)
            {
                return;
            }
        
            ScoreCount();
            SetMultiplierTime();
        }

        #endregion

        #region Tsukuyomi Callbacks

        public void SaveHighScore()
        {
            var highScore = PlayerPrefs.GetFloat(HIGH_SCORE_KEY);
            if (currentScore > highScore)
            {
                PlayerPrefs.SetFloat(HIGH_SCORE_KEY, currentScore);
            }
        }

        private void InitializeScorePrefs()
        {
            if (!PlayerPrefs.HasKey(HIGH_SCORE_KEY))
            {
                PlayerPrefs.SetFloat(HIGH_SCORE_KEY, 0f);
            }
        }

        private void ScoreCount()
        {
            currentScore += Time.deltaTime * multiplierScore;
            currentScoreTextUI.text = currentScore.ToString(TEXT_SCORE_FORMAT);
        }

        private void SetMultiplierTime() => MultiplierTime += Time.deltaTime * 0.000015f;

        #endregion
    
    }
}
