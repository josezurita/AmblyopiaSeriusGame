using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{


    public float speed = 1f;
    public ColliderDistance2D colldist;
    public GameObject circle1;
    public CircleCollider2D circle1coll;
    public float playerPosition;
    public float circlePosition;
    //public float circleCollPosition;
    public float playerScale;
    public float circleScale;
    public bool clickedOn = false;
    public float sumaScales;
    public float distance;
    public float unidad;
    public float playerRadius;
    public float circleRadius;
    public double porcentaje;



    private void Start()
    {
        circle1coll = circle1.GetComponent<CircleCollider2D>();

    }
    void Update()

    {
        
        transform.Translate(speed * Time.deltaTime, 0, 0);
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
        //porcentaje = (1 - System.Math.Abs(System.Convert.ToDouble(circlePosition - playerPosition) / circleRadius)) * 100;
        porcentaje = (circlePosition - playerPosition);
        //Debug.Log("DentroS");
        //        Debug.Log("My Position" + playerPosition);
        //      Debug.Log("Circle Position" + circlePosition);
        if (Input.GetMouseButtonDown(0))
        {
            clickedOn = true;
            Debug.Log("clicked");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("SALIO!!!!!!!!!!!!");
        Debug.Log("My Position" + playerPosition);
        Debug.Log("Circle Position" + circlePosition);
        Debug.Log("DentroEx");
        if (!clickedOn)
        {
            Debug.Log("GAME OVER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    



}
