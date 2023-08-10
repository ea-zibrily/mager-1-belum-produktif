using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject pausePanel;

    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.singleton.PlaySound(0);
        Time.timeScale = 1;
    }

    public void home()
    {
        //SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene("MainMenu-FA");
        AudioManager.singleton.PlaySound(0);
        Time.timeScale = 1;
    }

    public void levelselect()
    {
        //SceneManager.LoadScene("LevelSelect");
        SceneManager.LoadScene("LevelSelect-FA");
        AudioManager.singleton.PlaySound(0);
        Time.timeScale = 1;
    }

    public void pause()
    {
        pausePanel.SetActive(true);
        AudioManager.singleton.PlaySound(0);
        Time.timeScale = 0;
    }

    public void close()
    {
        pausePanel.SetActive(false);
        AudioManager.singleton.PlaySound(0);
        Time.timeScale = 1;
    }


}
