using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
}
