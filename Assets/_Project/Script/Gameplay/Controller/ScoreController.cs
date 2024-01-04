using System;
using BelumProduktif.Managers;
using UnityEngine;
using TMPro;

namespace BelumProduktif.Gameplay.Controller
{
    [AddComponentMenu("Tsukuyomi/Controller/ScoreController")]
    public class ScoreController : MonoBehaviour
    {
        #region Variable
    
        [Header("Score")] 
        [SerializeField] private float currentScore;
        [SerializeField] private float multiplierScore;
        public float MultiplierTime { get; private set; }
        
        [Header("Interface")]
        [SerializeField] private TextMeshProUGUI currentScoreTextUI;
        [SerializeField] private TextMeshProUGUI highScoreTextUI;
        
        // Constant n Static Variable
        private const string HIGH_SCORE_KEY = "HighScore";
        private const string TEXT_SCORE_FORMAT = "000000";

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            InitializeScorePrefs();
            InitializeScore();
        }

        private void Update()
        {
            if (!GameManager.Instance.IsGameStart)
            {
                return;
            }
            
            ScoreCount();
            SetMultiplierTime();
        }
        
        #endregion

        #region Tsukuyomi Callbacks

        private void InitializeScore()
        {
            currentScore = 0f;
            currentScoreTextUI.text = currentScore.ToString(TEXT_SCORE_FORMAT);
            highScoreTextUI.text = PlayerPrefs.GetFloat(HIGH_SCORE_KEY).ToString(TEXT_SCORE_FORMAT);
        }
        
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
