using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class G1GameManager : MonoBehaviour {

    public Transform circleGenerator;
    private Vector3 circleStartPoint;

    public G1Player thePlayer;
    private Vector3 playerStartPoint;

    private G1CircleDestroyer[] circleList;
    public GameObject[] circleDestroyer;

    public GameObject[] coinDestroyer;
    public DeathBehaviour theDeathScreen;

    private G1ScoreManager theScoreManager;
    private PauseBehaviourScript thePauseMenu;

    public int scoreToGivePerCoin;
    public bool coinIsPicked=false;
    public string isTutorialOn = "no";
    public GameObject tutorial;
    public GameObject tutorial1;

    // Use this for initialization
    void Start () {
        circleStartPoint = circleGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<G1ScoreManager>();


        //Inicializador de Tutorial
        PlayerPrefs.SetString("Tutorial", "si");

        if (PlayerPrefs.HasKey("Tutorial"))
        {
            isTutorialOn = PlayerPrefs.GetString("Tutorial");
            Debug.Log(PlayerPrefs.GetString("Tutorial")+ " hay Tutorial");
        }
        if (isTutorialOn == "si")
        {
            tutorial.SetActive(true);
            tutorial1.SetActive(true);
            coinIsPicked = true;

        }
        if (!tutorial.activeSelf)
        {
            Time.timeScale = 1f;
        }
        else
        {
            setTime(0);
            coinIsPicked = true;

        }

    }
	
	void Update () {

        if (!PauseBehaviourScript.GameIsPaused)
        {

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (Input.GetMouseButtonDown(0))
            {
                if (hit != null && hit.collider != null)
                {

                    Debug.Log("Coin");
                    if (hit.collider.tag == ("Coin"))
                    {
                        hit.collider.gameObject.SetActive(false);

                        coinIsPicked = true;
                        theScoreManager.addScore(scoreToGivePerCoin);

                    }
                }
            }
        }

       
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");
    }

    public void Reset()

    {
        Time.timeScale = 1f;
        theDeathScreen.gameObject.SetActive(false);

        circleList = FindObjectsOfType<G1CircleDestroyer>();

        for (int i = 0; i < circleList.Length; i++)
        {
            circleList[i].gameObject.SetActive(false);
        }

        circleDestroyer = GameObject.FindGameObjectsWithTag("Circle");

        foreach (GameObject cir in circleDestroyer)
        {
            cir.SetActive(false);
        }
        coinDestroyer = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in coinDestroyer)
        {
            coin.SetActive(false);
        }


        thePlayer.transform.position = playerStartPoint;
        circleGenerator.position = circleStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    public void setTime(int time)
    {
        float ftime;
        ftime = (float)time;
        Time.timeScale = ftime;
        Debug.Log("Time:" + ftime);
        
    }
    /*
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

        circleDestroyer = GameObject.FindGameObjectsWithTag("Circle");

        foreach (GameObject cir in circleDestroyer)
        {
            cir.SetActive(false);
        }
        coinDestroyer = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in coinDestroyer)
        {
            coin.SetActive(false);
        }


        thePlayer.transform.position = playerStartPoint;
        circleGenerator.position = circleStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

    }*/
}
