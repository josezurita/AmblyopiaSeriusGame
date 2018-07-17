using System;
using System.Collections;
using UnityEngine;

public class DifferentScript : MonoBehaviour {

    public GameObject figura;
    public float magnitud;
    public int numberOfFigures;
    
	// Use this for initialization
	void Start () {

        for (int i = 0; i<numberOfFigures; i++)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            GameObject instance = Instantiate(figura, screenPosition, Quaternion.identity);
            instance.GetComponent<FigureBehaviour>().magnitud = magnitud;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
