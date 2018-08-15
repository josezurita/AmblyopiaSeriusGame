using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonBehaviour : MonoBehaviour {

    public GUISkin guiSkin;

	// Use this for initialization
	void Start () {
        string currentScene = SceneManager.GetActiveScene().name;
        switch (currentScene)
        {
            case "MainMenu":
                HidePopUp("InfoPanel");
                HidePopUp("HelpPanel");
                break;
            case "":
                Debug.Log("Aquí los popUps de la escena correspondiente");
                break;
            default:
                break;
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

    public void HidePopUp(string popUpName)
    {
        try
        {
            GameObject popUp = GameObject.Find(popUpName);
            popUp.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.LogError("No se puede ocultar el pop up" + popUpName);
            Debug.LogException(e);
        }
        
    }
}
