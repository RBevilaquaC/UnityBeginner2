using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public GameObject gameOver;
    public static GameController instance;
    
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void showGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void newGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
