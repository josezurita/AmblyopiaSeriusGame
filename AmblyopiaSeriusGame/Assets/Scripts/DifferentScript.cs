using System;
using System.Collections;
using UnityEngine;

public class DifferentScript : MonoBehaviour {

    public GameObject figura;
    public float initialMagnitude;
    public int initialNumberOfFigures;
    public float initialScale;
    private float newMagnitude;
    private int newNumberOfFigures;
    private float newScale;
    private float maxMagnitude = 12f;
    private int maxNumberOfFigures = 15;
    private float minScale = 1.5f;

    // Use this for initialization
    void Start() {
        GenerateFigures(initialMagnitude, initialNumberOfFigures, initialScale);
        newScale = initialScale;
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
                    if (newMagnitude < maxMagnitude)
                    {
                        newMagnitude = initialMagnitude * 1.05f;
                    }
                    if (newNumberOfFigures < maxNumberOfFigures)
                    {
                        newNumberOfFigures = initialNumberOfFigures + 1;
                    }
                    if(newScale > minScale)
                    {
                        newScale = initialScale * 0.9f;
                        Debug.Log(newScale);
                    }
                    GenerateFigures(newMagnitude, newNumberOfFigures, newScale);
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

    public void GenerateFigures(float magnitude, int numberOfFigures, float scale)
    {
        initialMagnitude = magnitude;
        initialNumberOfFigures = numberOfFigures;
        initialScale = scale;
        DestroyFigures();
        int spriteFigura = UnityEngine.Random.Range(0, 4);
        int spriteColor = UnityEngine.Random.Range(0, 4);

        bool diferente = true;
        for (int i = 0; i < numberOfFigures; i++)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(Screen.width/10f, Screen.width - Screen.width / 10f), UnityEngine.Random.Range(Screen.height/10f, Screen.height - Screen.height / 10f), Camera.main.farClipPlane / 2));
            GameObject instance = Instantiate(figura, screenPosition, Quaternion.identity);
            instance.GetComponent<FigureBehaviour>().magnitud = magnitude;
            instance.GetComponent<FigureBehaviour>().setSprite(spriteFigura, spriteColor);
            instance.GetComponent<FigureBehaviour>().setScale(scale);
            if (diferente)
            {
                instance.GetComponent<FigureBehaviour>().diferente = diferente;
                int aleatorio = UnityEngine.Random.Range(0, 2);
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

    private void DestroyFigures()
    {
        GameObject[] figures = GameObject.FindGameObjectsWithTag("Figure");

        foreach (GameObject figure in figures)
        {
            Destroy(figure);
        }
    }
}
