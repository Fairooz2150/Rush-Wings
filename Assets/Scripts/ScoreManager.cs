using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreText;

    [ContextMenu("Increase Score")]
    public void addScore(int point)
    {
        playerScore = playerScore + point;
        scoreText.text = playerScore.ToString();
    }
}
