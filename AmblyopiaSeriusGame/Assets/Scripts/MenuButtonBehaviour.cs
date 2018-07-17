using System;
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
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }

    public void ExitButtonPressed()
    {
        Debug.Log("Salir de la aplicación");
        Application.Quit();
    }

    public void LoadPreviousScene()
    {
        string previousScene = PlayerPrefs.GetString("lastLoadedScene");
        if (previousScene != null)
        {
            SceneManager.LoadScene(previousScene);
        }
        else
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
