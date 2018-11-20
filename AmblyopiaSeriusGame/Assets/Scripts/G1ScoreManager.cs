using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;


public class G1ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    public Text levelUp;

    public float scoreCount;
    public float highScoreCount;
    public float previousHighScore;
    public float pointsPerSecond;

    public G1Player thePlayer;

    public bool scoreIncreasing;
    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<G1Player>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        previousHighScore = highScoreCount;


    }
	
	// Update is called once per frame
	void Update () {

        if (scoreIncreasing)
        {

            scoreCount += pointsPerSecond * Time.deltaTime;

        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            SaveHighScore();
        }

        scoreText.text = "Score: " + (int)scoreCount;
        highScoreText.text = "Highscore: " + (int)highScoreCount;
        levelUp.text = "Tu nivel: " + (int)thePlayer.level ;

    }

    public void addScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
    private void SaveHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", highScoreCount);//Guardar El HighScore
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Note: make sure to add 'using GooglePlayGames'
            PlayGamesPlatform.Instance.ReportScore(Mathf.RoundToInt(highScoreCount),
                GPGSIds.leaderboard_catch_coins,
                (bool success) =>
                {
                    Debug.Log("(Lollygagger) Leaderboard update success: " + success);
                });
        }

        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            int difference = (int)(highScoreCount - previousHighScore);
            if (highScoreCount - previousHighScore > 0 && previousHighScore < 500)
            {
                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_score_500_points_in_catch_coins, difference, (bool success) =>
                {
                    Debug.Log("500 points achievement increased: " + success);
                });
            }
          
            if (highScoreCount - previousHighScore > 0 && previousHighScore < 1000)
            {
                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_score_1000_points_in_catch_coins, difference, (bool success) =>
                {
                    Debug.Log("500 points achievement increased: " + success);
                });
            }       
            if (highScoreCount - previousHighScore > 0 && previousHighScore < 1500)
            {
                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_score_1500_points_in_catch_coins, difference, (bool success) =>
                {
                    Debug.Log("1000 points achievement increased: " + success);
                });
            }

        }
    }



}
