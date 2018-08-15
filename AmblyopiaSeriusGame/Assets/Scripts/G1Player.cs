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

    
    public G1GameManager theGameManager;

    private void Start()
    {
        level = 1;
        theGameManager = FindObjectOfType<G1GameManager>();
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

    }
    void Update()

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
                    die();
                }

                if (isInside)
                {
                    Debug.Log("IsInside");
                    GameObject.FindWithTag("Circle").SetActive(false);
                }
            }
            else
            {
                theGameManager.coinIsPicked = false;
            }
           
        }

        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            new MenuButtonBehaviour().LoadPreviousScene();
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        clickedOn = false;
        isInside = false;
        if (col.offset.x > 0)
        {
            die();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.offset.x < 0)
        {
            isInside = true;
        }
        else
        {
            isInside = false;
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
        Debug.Log("Level Up!");
    }




}
