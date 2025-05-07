using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }
    private int currentScore = 0;
    private int bestScore = 0;
    [SerializeField] UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }
    private void Awake()
    {
        gameManager = this;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        PlayerPrefs.Save();

    }
    private void Start()
    {
        //uiManager.UpdateScore(currentScore);
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
        
        if (currentScore >= bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            Debug.Log(bestScore);
        }
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
        if (currentScore > bestScore)
        {
            bestScore = currentScore; 
            uiManager.GameUI.UpdateBestScore();
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    
}
