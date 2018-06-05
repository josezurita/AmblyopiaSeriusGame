using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed = 1f;
    public Rigidbody2D rb;
   

    void Update () {
        transform.Translate(speed*Time.deltaTime, 0, 0);
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        Debug.Log(col.tag);
        if(col.tag == "Circle")
        {
            if (!Input.GetMouseButtonDown(0))
            {
                Debug.Log("Lo lograste");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }

}
