using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    public int playerScore;

    [Header("Live Score UI")]
     public TMP_Text scoreText;

    [Header("Game Over UI")]
    public TMP_Text currentScoreText;
    public TMP_Text bestScoreText;
    public GameObject gameOverScreen;
    public ScoreManager scoreManager;
    public AudioClip gameOverBgm;
    public bool shownGameOver = false;

    int highScore;

    void Start()
    {
        //Load saved high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && shownGameOver)
        {
            restartGame();
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int point)
    {
        playerScore = playerScore + point;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void showGameOver()
    {
        if (!shownGameOver)
        {
            UISoundManager.Play(gameOverBgm);
            shownGameOver = true;
            gameOverScreen.SetActive(true);

            currentScoreText.text =  playerScore.ToString();

            if (playerScore > highScore)
            {
                highScore=playerScore;

                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }

            bestScoreText.text = highScore.ToString();
        }
    }
}
