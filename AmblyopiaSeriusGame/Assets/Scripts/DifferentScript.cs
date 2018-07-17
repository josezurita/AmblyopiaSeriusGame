using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentScript : MonoBehaviour {

    public GameObject figura;
    public float magnitud;
    public int numberOfFigures;
    
	// Use this for initialization
	void Start () {
        //Vector3 pos = Camera.main.WorldToScreenPoint();
        for (int i = 0; i<numberOfFigures; i++)
        {
            //Instantiate(figura, new Vector3(Random.range(),Random.range()),Quaternion.identity);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
