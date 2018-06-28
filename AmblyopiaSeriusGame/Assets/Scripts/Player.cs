using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public float speed = 1f;
    public ColliderDistance2D colldist;
    public GameObject circle1;
    public Collider2D circle1coll;
    public bool changedOverlapped = false;
    public bool wasOverlapped = false;
    public bool clickedOn = false;



    private void Start()
    {
        circle1coll = circle1.GetComponent<Collider2D>();

    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        clickedOn = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {  
        if (Input.GetMouseButtonDown(0))
        {
            clickedOn = true;
            Debug.Log("clicked");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!clickedOn)
        {
            Debug.Log("GAME OVER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    



}
