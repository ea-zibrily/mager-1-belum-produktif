using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("LESGO!");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("MainMenu");
            SceneManager.LoadScene("MainMenu-FA");
            AudioManagerOld.singleton.PlaySound(0);
        }
    }
    public void level1()
    {
        //SceneManager.LoadScene("Level1");
        SceneManager.LoadScene("Level1-FA");
        AudioManagerOld.singleton.PlaySound(0);
    }
    public void level2()
    {
        //SceneManager.LoadScene("Level2");
        SceneManager.LoadScene("Level2-FA");
        AudioManagerOld.singleton.PlaySound(0);
    }
    public void level3()
    {
        //SceneManager.LoadScene("Level3");
        SceneManager.LoadScene("Level3-FA");
        AudioManagerOld.singleton.PlaySound(0);
    }
    
}
