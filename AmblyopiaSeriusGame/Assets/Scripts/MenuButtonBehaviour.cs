using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void ExitButtonPressed()
    {
        Debug.Log("Salir de la aplicación");
        Application.Quit();
    }
}
