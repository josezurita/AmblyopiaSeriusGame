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
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreCount += pointsPerSecond * Time.deltaTime / 5;

        scoreText.text = "Score: " + (int)scoreCount;
        highScoreText.text = "Highscore: " + highScoreCount;

    }
}
