using BelumProduktif.DesignPattern.Singleton;
using BelumProduktif.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BelumProduktif.Managers
{
    [AddComponentMenu("Tsukuyomi/Managers/SceneTransitionManager")]
    public class SceneTransitionManager : MonoSingleton<SceneTransitionManager>
    {
        #region Variable
    
        [Header("Interface")]
        [SerializeField] private RectTransform sceneFader;
    
        #endregion
    
        #region MonoBehaviour Callbacks

        private void Start()
        {
            if (GameManager.Instance.IsHavePlayed)
            {
                //--- Directional Fader w FEEL
                FeedbackManager.Instance.CallDirectionalOut();
                var directionalOutEvent = FeedbackManager.Instance.GetDirectionalOut().Events;
                directionalOutEvent.OnComplete.AddListener(StartGame);
            }
            else
            {
                //--- Og Fader w LeanTween
                StartFader();
            
                //--- Fader w FEEL
                // FeedbackManager.Instance.CallFader();
            }
        }
    
        #endregion

        #region Tsukuyomi Callbacks
        
        public void SceneMoveController()
        {
            FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Click);
            OpenCurrentScene();
        }
        
        private void StartFader()
        {
            sceneFader.gameObject.SetActive (true);
        
            LeanTween.alpha (sceneFader, 1, 0);
            LeanTween.alpha (sceneFader, 0, 1f).setOnComplete (() => {
                sceneFader.gameObject.SetActive (false);
            });
        }
        
        private void OpenCurrentScene()
        {
            Time.timeScale = 1;
            sceneFader.gameObject.SetActive (true);

            LeanTween.alpha(sceneFader, 0, 0);
            LeanTween.alpha (sceneFader, 1, 0.5f).setOnComplete (() => {
                Invoke ("LoadGame", 0.5f);
            });
        }
        
        private void LoadGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        private void StartGame() => GameManager.Instance.GameStartEvent();

        #endregion

    }
}
