using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour : MonoBehaviour {
    public string mainMenuLevel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitButtonClick();
        }
    }
    public void RestartGame () {
        FindObjectOfType<G1GameManager>().Reset();
	}

    public void ExitButtonClick()
    {
        new MenuButtonBehaviour().LoadPreviousScene();
    }
    
}
