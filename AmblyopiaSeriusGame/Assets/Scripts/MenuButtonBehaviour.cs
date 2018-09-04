using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonBehaviour : MonoBehaviour {

    public GUISkin guiSkin;
    public GameObject confirmationPanel;
    private GameObject[] menuButtons;
    private string currentScene;

    private void Awake()
    {
        menuButtons = GameObject.FindGameObjectsWithTag("MenuButton");
        currentScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentScene.Equals("MainMenu")){
                if (confirmationPanel.activeSelf)
                {
                    confirmationPanel.SetActive(false);
                    toogleInteractableMainMenuButtons();
                }
                else
                {
                    confirmationPanel.SetActive(true);
                    toogleInteractableMainMenuButtons();
                }
            }
            else
            {
                LoadPreviousScene();
            }
        }
    }

    public void toogleInteractableMainMenuButtons()
    {
        foreach (GameObject menuButton in menuButtons)
        {
            if (menuButton.GetComponent<UnityEngine.UI.Button>().IsInteractable() == true)
            {
                menuButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
            else //Else make it interactable
            {
                menuButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
            }
        }

    }

    private void OnGUI()
    {
        GUI.skin = guiSkin;
    }

    public void LoadScene(string sceneName)
    {
        String[] navigationArray = null;
        Stack<String> navigation = new Stack<string>();
        try
        {
            navigationArray = PlayerPrefsX.GetStringArray("navigation");
            Array.Reverse(navigationArray);
            navigation = new Stack<string>(navigationArray);

        }
        catch(Exception e)
        {
            Debug.Log(e.StackTrace);
        }
        navigation.Push(SceneManager.GetActiveScene().name);
        navigationArray = navigation.ToArray();
        Debug.Log("navigation.lenght: " + navigationArray.Length);
        printArray(navigationArray);
        PlayerPrefsX.SetStringArray("navigation", navigationArray);
        SceneManager.LoadScene(sceneName);
    }

    private void printArray(string[] navigationArray)
    {
        int index = 0;
        foreach(String item in navigationArray)
        {
            Debug.Log(index + ".-" + item);
            index++;
        }
    }

    public void ExitButtonPressed()
    {
        Debug.Log("Salir de la aplicación");
        String[] navigationArray = { };
        PlayerPrefsX.SetStringArray("navigation", navigationArray);
        Application.Quit();
    }

    public void LoadPreviousScene()
    {
        String[] navigationArray = null;
        Stack<String> navigation = new Stack<string>();
        try
        {
            navigationArray = PlayerPrefsX.GetStringArray("navigation");
            Array.Reverse(navigationArray);
            navigation = new Stack<string>(navigationArray);

        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
        }
        try
        {
            SceneManager.LoadScene(navigation.Pop());
            navigationArray = navigation.ToArray();
            Debug.Log("navigation.lenght: " + navigationArray.Length);
            PlayerPrefsX.SetStringArray("navigation", navigationArray);
        }
        catch
        {
            Debug.Log("No hay escena previa");
        }
    }
}
