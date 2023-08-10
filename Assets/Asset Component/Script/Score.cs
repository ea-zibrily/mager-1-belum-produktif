using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    private Text scoreText;
    public Text  HIscoreText;
    
    private string Highscore = "Highscore";
    private string Defscore = "00000";

    private float timer;
    private float maxTime;

    void Start()
    {
        HIscoreText.text = "HI " + PlayerPrefs.GetInt(Highscore, 0).ToString(Defscore);
        score = 0;
        scoreText = GetComponent<Text>();
        maxTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            score++;
            scoreText.text = score.ToString(Defscore);
            timer = 0;
        }
        
        if (Time.timeScale == 0)
        {
            
            if (score > PlayerPrefs.GetInt(Highscore, 0))
            {
                PlayerPrefs.SetInt(Highscore, score);
                HIscoreText.text = "HI " + PlayerPrefs.GetInt(Highscore, 0).ToString(Defscore);
            }
        }
        
    }
}
