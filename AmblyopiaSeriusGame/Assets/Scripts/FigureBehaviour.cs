using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureBehaviour : MonoBehaviour {

    private Vector3 randomVector;
    private new Rigidbody2D rigidbody2D;
    private float magnitud;

    // Use this for initialization
    void Start () {
        int x = Random.Range(-10, 10);
        int y = Random.Range(-10, 10);
        randomVector = new Vector3(x, y);
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = (Vector3.ClampMagnitude(randomVector,0.5f)*magnitud);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("x: " + rigidbody2D.velocity.x);
        Debug.Log("y: " + rigidbody2D.velocity.y);
    }
}
