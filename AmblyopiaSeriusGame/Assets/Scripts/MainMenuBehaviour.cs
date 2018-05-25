using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if(GUI.Button(new Rect((Screen.width / 2.0f - Screen.width / 8.0f), 0, Screen.width / 4.0f, Screen.height / 10.0f), "Play")) {
            SceneManager.LoadScene(1);
        }
        if(GUI.Button(new Rect((Screen.width / 2.0f - Screen.width / 8.0f), Screen.height / 10.0f, Screen.width / 4.0f, Screen.height / 10.0f), "Exit")) {
            Application.Quit();
        }
    }
}
