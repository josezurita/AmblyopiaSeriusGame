using GooglePlayGames;
using GooglePlayGames.BasicApi;
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
        highScoreLabel.text = "High Score: " + Mathf.RoundToInt(highScore);
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
        float previousHighScore = getPreviousHighScore();
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
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            int difference = (int) (highScore - previousHighScore);
            if (highScore - previousHighScore > 0 && previousHighScore < 500)
            {
                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_score_500_points_in_find_the_stowaway, difference, (bool success) =>
                {
                    Debug.Log("500 points achievement increased: " + success);
                });
            }
          
            if (highScore - previousHighScore > 0 && previousHighScore < 1000)
            {
                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_score_1000_points_in_find_the_stowaway, difference, (bool success) =>
                {
                    Debug.Log("500 points achievement increased: " + success);
                });
            }
            if (highScore - previousHighScore > 0 && previousHighScore < 1500)
            {
                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_score_1500_points_in_find_the_stowaway, difference, (bool success) =>
                {
                    Debug.Log("1000 points achievement increased: " + success);
                });
            }

        }
        // Increment the "sharpshooter" achievement
        //PlayGamesPlatform.Instance.IncrementAchievement(
        //       GPGSIds.achievement_sharpshooter,
        //       1,
        //       (bool success) => {
        //           Debug.Log("(Lollygagger) Sharpshooter Increment: " +
        //                 success);
        //       });
        highScoreLabel.text = "High Score: " + Mathf.RoundToInt(highScore);
    }

    private float getPreviousHighScore()
    {
        float savedHighScore = 0f;
        try
        {
            PlayGamesPlatform.Instance.LoadScores(GPGSIds.leaderboard_find_the_stowaway,
             LeaderboardStart.PlayerCentered,
             1,
             LeaderboardCollection.Public,
             LeaderboardTimeSpan.AllTime,
         (LeaderboardScoreData data) => {
             savedHighScore = float.Parse(data.PlayerScore.formattedValue);
         });
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
        }
        return savedHighScore;
    }

    private float CalculateTimePercentage()
    {
        return currentTime / maxTime;
    }
}
