using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoSingleton<SceneTransitionManager>
{
    #region Variable
    
    [SerializeField] private RectTransform sceneFader;
    private GameManager gameManager;
    
    #endregion
    
    #region MonoBehaviour Callbacks

    protected override void Awake()
    {
        base.Awake();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        StartFader();
    }
    
    #endregion

    #region Tsukuyomi Callbacks
    
    public void SceneMoveController()
    {
        FindObjectOfType<AudioManager>().PlayAudio(SoundEnum.SFX_Click);
        gameManager.IsGamePlay = true;
        Time.timeScale = 1;
        
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
        sceneFader.gameObject.SetActive (true);
        
        LeanTween.alpha (sceneFader, 0, 0);
        LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => {
            // Example for little pause before laoding the next scene
            Invoke ("LoadGame", 0.5f);
        });
    }
    
    private void LoadGame () => SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
   
    #endregion

}
