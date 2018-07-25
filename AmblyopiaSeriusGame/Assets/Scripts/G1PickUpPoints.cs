using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1PickUpPoints : MonoBehaviour {
    public int scoreToGivePerCoin;
    private G1ScoreManager theScoreManager;
    private G1GameManager theGameManager;


    // Use this for initialization
    void Start () {
        theScoreManager = FindObjectOfType<G1ScoreManager>();
        theGameManager = FindObjectOfType<G1GameManager>();

    }

    // Update is called once per frame
    void Update () {

       
    }
}
