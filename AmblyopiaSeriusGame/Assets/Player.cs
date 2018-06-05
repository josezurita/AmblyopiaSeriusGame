using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float jumpForce = 10f;
    public Rigidbody2D rb;
   

    void Update () {
		
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
