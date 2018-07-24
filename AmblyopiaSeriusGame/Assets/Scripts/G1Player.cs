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
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
            Debug.Log("Level Up!");
        }
        
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

       
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        playerScale = this.transform.localScale.x;
        circlePosition = col.transform.position.x;
        circleScale = col.transform.localScale.x;
        playerPosition = this.transform.position.x;
        clickedOn = false;
        sumaScales = playerScale + circleScale;
        distance = circlePosition - playerPosition;
        unidad = distance / sumaScales;
        circleRadius =  unidad * circleScale / 2;
        playerRadius = unidad * playerScale / 2;
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        circlePosition = col.transform.position.x;
        playerPosition = this.transform.position.x;
        
       if (playerPosition < circlePosition - circleRadius + playerRadius || playerPosition > circlePosition + circleRadius - playerRadius)
        {

            if (Input.GetMouseButtonDown(0))
            {
                clickedOn = true;
                Debug.Log("clicked");
            }
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!clickedOn)
        {
            Debug.Log("GAME OVER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11");
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
           speedIncreaseMilestone = speedIncreaseMilestoneStore ;

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    



}
