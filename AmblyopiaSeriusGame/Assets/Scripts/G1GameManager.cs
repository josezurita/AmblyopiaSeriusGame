using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1GameManager : MonoBehaviour {

    public Transform circleGenerator;
    private Vector3 circleStartPoint;

    public G1Player thePlayer;
    private Vector3 playerStartPoint;

    private G1CircleDestroyer[] circleList;

    private G1ScoreManager theScoreManager;

    // Use this for initialization
    void Start () {
        circleStartPoint = circleGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<G1ScoreManager>();
		
	}
	
	void Update () {
		
	}

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;   
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        circleList = FindObjectsOfType<G1CircleDestroyer>();
        for (int i=0; i < circleList.Length; i++)
        {
            circleList[i].gameObject.SetActive(false);
        }


        thePlayer.transform.position = playerStartPoint;
        circleGenerator.position = circleStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

    }
}
