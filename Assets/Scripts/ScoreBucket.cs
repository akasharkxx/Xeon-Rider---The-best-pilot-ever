using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBucket : Singleton<ScoreBucket>
{
    private static int score = 0;
    Text scoreText;
    private void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateUIText();
    }

    public void ChangeScore(int addScore)
    {
        score += addScore;
        UpdateUIText();
    }

    private void UpdateUIText()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
