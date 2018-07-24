using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G1ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;
    // Use this for initialization
    void Start () {

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
		
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
            PlayerPrefs.SetFloat("HighScore",highScoreCount);//Guardar El HighScore
        }

        scoreText.text = "Score: " + (int)scoreCount;
        highScoreText.text = "Highscore: " + (int)highScoreCount;

    }
}
