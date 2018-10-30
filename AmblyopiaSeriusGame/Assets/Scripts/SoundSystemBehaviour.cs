using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystemBehaviour : MonoBehaviour {

    public GameObject soundButton;
    public GameObject musicButton;
    private bool musicIsOn;
    private bool soundIsOn;

	// Use this for initialization
	void Start () {
        //Desactivado hasta agregar lógica
		soundButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
        musicButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
