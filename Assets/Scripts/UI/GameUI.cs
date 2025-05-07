using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : BaseUI
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;


    public void Init()
    {
        bestScoreText.text = GameManager.Instance.GetBestScore().ToString();
    }

    public void UpdateScore(int score)
    {

        
        scoreText.text = score.ToString();

    }

    public void UpdateBestScore()
    {
       
            bestScoreText.color = Color.red;
            bestScoreText.text = GameManager.Instance.GetBestScore().ToString();
    }

}
