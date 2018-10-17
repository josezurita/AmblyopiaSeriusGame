using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehaviourScript : MonoBehaviour {

    public static bool GameIsPaused = false;
    public static bool GameOver = false;
    public GameObject PauseMenuUI;
    public GameObject DeathMenuUI;

	// Use this for initialization
	void Start () {
        GameOver = false;
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
        DeathMenuUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused && !GameOver)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        if (GameOver && !DeathMenuUI.activeSelf)
        {
            ShowGameOverScreen();
        }
    }

    private void ShowGameOverScreen()
    {
        DeathMenuUI.SetActive(true);
        GameOver = false;
        Time.timeScale = 0f;
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
        GameOver = false;
    }

    public void Restart()
    {
        GameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButtonClick()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameOver = false;
        new MenuButtonBehaviour().LoadPreviousScene();
    }
}
