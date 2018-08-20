using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1CircleGenerator : MonoBehaviour {

    public GameObject theCircle;
    public GameObject thePlayer;
    public CircleCollider2D theCircleCollider;
    public Transform generationPoint;

    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private float circleRadius;
    private float circleScale;
    private float circleScaleMin;
    private float circleScaleMax;
    public float circleIndexMax;
    public float circleIndexMin;
    private float circleIndexBound;
    public int percentOfCoins;

    public G1ObjectPooler theObjectPool;
    public G1CoinGenerator theCoinGenerator;
    
         
    // Use this for initialization
    void Start () {
        circleRadius = theCircle.GetComponent<CircleCollider2D>().radius;
        theCoinGenerator = FindObjectOfType<G1CoinGenerator>() ;
        circleIndexMax = 4;
        circleIndexMin = 3;
        circleIndexBound = 1+ 1f;
        percentOfCoins = 100;
	}
	
	// Update is called once per frame      
	void Update () {
      
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + circleRadius + distanceBetween, transform.position.y, transform.position.z);
            
            //Instantiate(theCircle, transs form.position, transform.rotation);
            GameObject newCircle = theObjectPool.GetPooledObject();
            if (circleIndexMin < circleIndexBound)
            {
                circleIndexMin = circleIndexBound;
            }

            circleScaleMin = thePlayer.transform.localScale.x * circleIndexMin;
            circleScaleMax = thePlayer.transform.localScale.x * circleIndexMax;
            circleScale = Random.Range(circleScaleMin, circleScaleMax);

            newCircle.transform.position = transform.position;
            newCircle.transform.rotation = transform.rotation;
            newCircle.transform.localScale = new Vector3(circleScale, circleScale, 0);
            newCircle.SetActive(true);
            

            Debug.Log(Random.Range(percentOfCoins, 100));

            if (Random.Range(percentOfCoins, 100) / 10 == percentOfCoins/10)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x + 4f, transform.position.y + 4f, transform.position.z));
            }

        }

    }
}
