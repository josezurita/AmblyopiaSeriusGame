using GooglePlayGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DGScoreScript : MonoBehaviour {

    public float currentTime;
    public float maxTime;
    public Slider timeBar;
    public Text scoreLabel;
    public Text highScoreLabel;
    public float score;
    public float highScore;

	// Use this for initialization
	void Start () {
        currentTime = 0;
        score = 0;
        highScore = 0f;
        if (PlayerPrefs.HasKey("G2HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("G2HighScore");
        }
    }

    public void RestartTimer(float newTime)
    {
        score += currentTime * 10;
        scoreLabel.text = "Score: " + Mathf.RoundToInt(score);
        maxTime = newTime;
        currentTime = newTime;
        timeBar.value = CalculateTimePercentage();
    }

    // Update is called once per frame
    void Update () {
        currentTime -= Time.deltaTime;
        timeBar.value = CalculateTimePercentage();
        if (currentTime <= 0)
            Die();
	}

    private void Die()
    {
        SaveHighScore();
        PauseBehaviourScript.GameOver = true;
    }

    private void SaveHighScore()
    {
        if (score > highScore)
        {
            Debug.Log("Nuevo puntaje máximo");
            highScore = score;
            PlayerPrefs.SetFloat("G2HighScore", highScore);
            if (PlayGamesPlatform.Instance.localUser.authenticated)
            {
                // Note: make sure to add 'using GooglePlayGames'
                PlayGamesPlatform.Instance.ReportScore(Mathf.RoundToInt(highScore),
                    GPGSIds.leaderboard_find_the_stowaway,
                    (bool success) =>
                    {
                        Debug.Log("(Lollygagger) Leaderboard update success: " + success);
                    });
            }
        }
        highScoreLabel.text = "High Score: " + Mathf.RoundToInt(highScore);
    }

    private float CalculateTimePercentage()
    {
        return currentTime / maxTime;
    }
}
