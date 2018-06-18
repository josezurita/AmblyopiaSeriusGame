using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed = 1f;
    public Rigidbody2D rb;
    public ColliderDistance2D colldist;
    public GameObject circle1;
    public Collider2D circle1coll;
    public bool changedOverlapped =false ;
    public bool wasOverlapped = false;
    public bool clickedOn = false;



    private void Start()
    {
        circle1coll = circle1.GetComponent<Collider2D>();

    }
    void Update () {

        transform.Translate(speed * Time.deltaTime, 0, 0);
        colldist = gameObject.GetComponent<Collider2D>().Distance(circle1coll);

        changedOverlapped = (!colldist.isOverlapped && wasOverlapped) ? true : false ;
        /*if (!colldist.isOverlapped && wasOverlapped)
        {
            changedOverlapped = true;
        }
        else
        {
            changedOverlapped = false;
        }*/
        if (colldist.isOverlapped && Input.GetMouseButtonDown(0))
        {
            clickedOn = true;
            Debug.Log("clicked");
        }

        if (changedOverlapped && !clickedOn)
        {
            Debug.Log("GAME OVER!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        wasOverlapped = colldist.isOverlapped;
    }

    

}
