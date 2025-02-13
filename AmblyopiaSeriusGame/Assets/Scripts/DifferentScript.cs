﻿using GooglePlayGames;
using System;
using System.Collections;
using UnityEngine;

public class DifferentScript : MonoBehaviour {

    public GameObject figura;
    public GameObject cameraShaker;
    public GameObject timer;
    public float initialMagnitude;
    public int initialNumberOfFigures;
    public float initialScale;
    public float initialTime;
    private float newMagnitude;
    private int newNumberOfFigures;
    private float newScale;
    private float newTime;
    private float maxMagnitude = 12f;
    private int maxNumberOfFigures = 15;
    private float minScale = 1.5f;
    private float minTime = 2f;

    // Use this for initialization
    void Start() {
        GenerateFigures(initialMagnitude, initialNumberOfFigures, initialScale, initialTime);
        newScale = initialScale;
        newTime = initialTime;
        Vector3 ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        GameObject EdgeUp = GameObject.Find("EdgeUp");
        EdgeUp.transform.position = new Vector3(0, ScreenSize.y, 0);
        GameObject EdgeDown = GameObject.Find("EdgeDown");
        EdgeDown.transform.position = new Vector3(0, -ScreenSize.y, 0);
        GameObject EdgeRight = GameObject.Find("EdgeRight");
        EdgeRight.transform.position = new Vector3(ScreenSize.x, 0, 0);
        GameObject EdgeLeft = GameObject.Find("EdgeLeft");
        EdgeLeft.transform.position = new Vector3(-ScreenSize.x, 0, 0);

        if (Social.localUser.authenticated)
        {
            // Unlock the "welcome" achievement, it is OK to
            // unlock multiple times, only the first time matters.
            PlayGamesPlatform.Instance.ReportProgress(
                GPGSIds.achievement_try_find_the_stowaway,
                100.0f, (bool result) =>
                {
                    Debug.Log("(Lollygagger) Welcome Unlock: " + result);
                });
        }
    }

    // Update is called once per frame
    void Update () {
        if (!PauseBehaviourScript.GameIsPaused)
        {
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
                        if (newScale > minScale)
                        {
                            newScale = initialScale * 0.9f;
                        }
                        if(newTime > minTime)
                        {
                            newTime = initialTime * 0.9f;
                            Debug.Log(newTime);
                        }
                        GenerateFigures(newMagnitude, newNumberOfFigures, newScale, newTime);
                    }
                    else
                    {
                        cameraShaker.GetComponent<CameraShake>().Shake(0.1f, 0.2f);
                    }

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

    public void GenerateFigures(float magnitude, int numberOfFigures, float scale, float time)
    {
        initialMagnitude = magnitude;
        initialNumberOfFigures = numberOfFigures;
        initialScale = scale;
        initialTime = time;
        DestroyFigures();
        int spriteFigura = UnityEngine.Random.Range(0, 4);
        int spriteColor = UnityEngine.Random.Range(0, 4);
        timer.GetComponent<DGScoreScript>().RestartTimer(initialTime);

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
