using UnityEngine;
using UnityEngine.SceneManagement;


public class G1Player : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;

    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    public float speedMilestoneCount;
    public float speedMilestoneCountStore;

    private int level;

    public bool clickedOn = false;
    public bool isInside = false;

    public ColliderDistance2D colldist;

    public GameObject tutorial;
    public G1GameManager theGameManager;
    public G1CircleGenerator theCircleGenerator;

    private void Start()
    {
        level = 1;
        theGameManager = FindObjectOfType<G1GameManager>();
        theCircleGenerator = FindObjectOfType<G1CircleGenerator>();
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

    }
    void Update()

    {

        if (!PauseBehaviourScript.GameIsPaused)
        {
            if (transform.position.x > speedMilestoneCount)
            {
                levelUp();
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (!theGameManager.coinIsPicked)
                {
                    Debug.Log("Clic");
                    if (!isInside)
                    {
                        if (!tutorial.activeSelf)
                        {
                            die();
                            Debug.Log("Murio por clic afuera");
                        }
                        

                    }

                    if (isInside)
                    {
                        Debug.Log("IsInside");
                        GameObject.FindWithTag("Circle").SetActive(false);
                        isInside = false;
                    }
                }
                else
                {
                    theGameManager.coinIsPicked = false;
                }

            }

            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

        }

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        clickedOn = false;
        isInside = false;
        if (col.offset.x > 0)
        {
            Debug.Log("Murio no hacer clic");

            die();
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.offset.x < 0)
        {
            Debug.Log("Entro al circulo");

            isInside = true;
        }
        else if (col.offset.x > 0)
        {
            isInside = false;
            Debug.Log("Salio del circulo");

        }


    }

    public void die()
    {
        Debug.Log("GAME OVER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11");
        theGameManager.RestartGame();
        moveSpeed = moveSpeedStore;
        speedMilestoneCount = speedMilestoneCountStore;
        speedIncreaseMilestone = speedIncreaseMilestoneStore;

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void levelUp()
    {

        level++;
        speedMilestoneCount += speedIncreaseMilestone;

        speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
        moveSpeed = moveSpeed * speedMultiplier;
        theCircleGenerator.percentOfCoins = theCircleGenerator.percentOfCoins * 95 / 100;
        theCircleGenerator.circleIndexMax = theCircleGenerator.circleIndexMax * 95 / 100;
        theCircleGenerator.circleIndexMin = theCircleGenerator.circleIndexMin * 95 / 100;
        Debug.Log("Level Up!");

    }




}
