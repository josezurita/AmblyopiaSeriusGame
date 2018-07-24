using System;
using System.Collections;
using UnityEngine;

public class DifferentScript : MonoBehaviour {

    public GameObject figura;
    public float magnitud;
    public int numberOfFigures;
    
	// Use this for initialization
	void Start () {
        int spriteFigura = UnityEngine.Random.Range(0,4);
        int spriteColor = UnityEngine.Random.Range(0,4);

        bool diferente = true;
        for (int i = 0; i<numberOfFigures; i++)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            GameObject instance = Instantiate(figura, screenPosition, Quaternion.identity);
            instance.GetComponent<FigureBehaviour>().magnitud = magnitud;
            instance.GetComponent<FigureBehaviour>().setSprite(spriteFigura,spriteColor);
            if (diferente)
            {
                instance.GetComponent<FigureBehaviour>().diferente = diferente;
                int aleatorio = UnityEngine.Random.Range(0,2);
                Debug.Log("Aleatorio: " + aleatorio);
                if (aleatorio == 1)
                {
                   instance.GetComponent<FigureBehaviour>().setSprite(spriteFigura, RandomExclude(spriteColor));
                }
                else
                {
                    instance.GetComponent<FigureBehaviour>().setSprite(RandomExclude(spriteFigura), spriteColor);
                }
                diferente = false;
            }

        }
        
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            if (hit != null && hit.collider != null)
            {
                if (hit.collider.GetComponent<FigureBehaviour>().diferente)
                {
                    Debug.Log("I'm hitting " + hit.collider.name);
                    hit.collider.GetComponent<FigureBehaviour>().setSprite(UnityEngine.Random.Range(0,4),UnityEngine.Random.Range(0,4));
                }

            }
        }        
    }

    private int RandomExclude(int excluded)
    {
        int newDir;

        newDir = UnityEngine.Random.Range(0,4);
        while (newDir == excluded)
        {
            newDir = UnityEngine.Random.Range(0,4);
        }

        return newDir;
    }
}
