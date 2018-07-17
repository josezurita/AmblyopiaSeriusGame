using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGenerator : MonoBehaviour {

    public GameObject theCircle;
    public CircleCollider2D theCircleCollider;
    public Transform generationPoint;

    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private float circleRadius;
    private float circleRadiusMin;
    private float circleRadiusMax;

    public ObjectPooler theObjectPool;

    // Use this for initialization
    void Start () {
        circleRadius = theCircle.GetComponent<CircleCollider2D>().radius;
	}
	
	// Update is called once per frame      
	void Update () {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + circleRadius + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(theCircle, transs form.position, transform.rotation);
            GameObject newCircle = theObjectPool.GetPooledObject();

            newCircle.transform.position = transform.position;
            newCircle.transform.rotation = transform.rotation;
            newCircle.SetActive(true);

        }
		
	}
}
