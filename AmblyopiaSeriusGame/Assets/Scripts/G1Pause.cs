using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1Pause : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    // Use this for initialization
    void Start()
    {
       
        PauseMenuUI.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
      
    }

    public void ExitButtonClick()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        new MenuButtonBehaviour().LoadPreviousScene();
    }
}
