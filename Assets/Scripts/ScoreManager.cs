using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    public int playerScore;
    public TMP_Text scoreText;
    public GameObject gameOverScreen;
    public ScoreManager scoreManager;
    public AudioClip gameOverBgm;
    bool shownGameOver = false;
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
        }
    }
}
