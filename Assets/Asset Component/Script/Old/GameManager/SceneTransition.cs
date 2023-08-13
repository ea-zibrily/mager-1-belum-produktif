using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] RectTransform fader;

    private void Start()
    {
        fader.gameObject.SetActive(true);

        //ALPHA
        LeanTween.alpha(fader, 1, 0.5f);
        LeanTween.alpha(fader, 0, 1).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });

    }

    public void OpenMenuScene()
    {
        fader.gameObject.SetActive(true);

        // ALPHA
        LeanTween.alpha (fader, 0, 0.5f);
        LeanTween.alpha (fader, 1, 1).setOnComplete (() => 
        {
           SceneManager.LoadScene(0);
         });

    }

    public void OpenSelectLevelScene()
    {
        fader.gameObject.SetActive(true);

        // ALPHA
        LeanTween.alpha (fader, 0, 0.5f);
        LeanTween.alpha (fader, 1, 1).setOnComplete (() => 
        {
            SceneManager.LoadScene(1);
        });

    }

    public void Level1()
    {
        fader.gameObject.SetActive(true);

        // ALPHA
        LeanTween.alpha(fader, 0, 0.5f);
        LeanTween.alpha(fader, 1, 1).setOnComplete(() =>
        {
            SceneManager.LoadScene(2);
        });

    }

    public void Level2()
    {
        fader.gameObject.SetActive(true);

        // ALPHA
        LeanTween.alpha(fader, 0, 0.5f);
        LeanTween.alpha(fader, 1, 1).setOnComplete(() =>
        {
            SceneManager.LoadScene(3);
        });

    }

    public void Level3()
    {
        fader.gameObject.SetActive(true);

        // ALPHA
        LeanTween.alpha(fader, 0, 0.5f);
        LeanTween.alpha(fader, 1, 1).setOnComplete(() =>
        {  
            SceneManager.LoadScene(4);
        });

    }

}