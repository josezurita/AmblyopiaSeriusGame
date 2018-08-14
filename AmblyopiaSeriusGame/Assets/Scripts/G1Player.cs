using UnityEngine;
using UnityEngine.SceneManagement;


public class G1Player : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;

    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;


    public bool clickedOn = false;
    public bool isInside = false;

    public ColliderDistance2D colldist;
    public GameObject circle1;
    public CircleCollider2D circle1coll;

    public float playerPosition;
    public float circlePosition;
    public float playerScale;
    public float circleScale;
    public float sumaScales;
    public float distance;
    public float unidad;
    public float playerRadius;
    public float circleRadius;

    public G1GameManager theGameManager;

    private void Start()
    {
        circle1coll = circle1.GetComponent<CircleCollider2D>();

        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

    }
    void Update()

    {
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
            Debug.Log("Level Up!");
        }
        if (Input.GetMouseButton(0))
        {
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

        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        clickedOn = false;
        isInside = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetMouseButton(0))
        {
            clickedOn = false;
            Debug.Log("clicked");
            die();
        }

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




}
