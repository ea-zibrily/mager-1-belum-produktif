using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMManager : MonoBehaviour
{
    public GameObject creditBar;
    public GameObject tutorBar;

    private void Awake()
    {
        creditBar.SetActive(false);
        tutorBar.SetActive(false);
    }

    public void goPlay()
    {
        //SceneManager.LoadScene("LevelSelect");
        SceneManager.LoadScene("LevelSelect-FA");
        AudioManagerOld.singleton.PlaySound(0);
    }

    public void credit()
    {
        creditBar.SetActive(true);
        AudioManagerOld.singleton.PlaySound(0);
    }

    public void tutor()
    {
        tutorBar.SetActive(true);
        AudioManagerOld.singleton.PlaySound(0);
    }
}
