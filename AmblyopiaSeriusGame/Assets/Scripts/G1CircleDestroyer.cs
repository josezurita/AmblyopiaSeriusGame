﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1CircleDestroyer : MonoBehaviour {

    public GameObject circleDestructionPoint;

	// Use this for initialization
	void Start () {
        circleDestructionPoint = GameObject.Find ("CircleDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
        if (!PauseBehaviourScript.GameIsPaused)
        {
            if (transform.position.x < circleDestructionPoint.transform.position.x)
            {
                //Destroy(gameObject);

                gameObject.SetActive(false);

            }
        }
		
	}
}
