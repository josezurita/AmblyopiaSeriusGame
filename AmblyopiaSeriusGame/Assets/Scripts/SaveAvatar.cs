using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAvatar : MonoBehaviour {

	// Use this for initialization
	
	
	public void saveAvatar(int avatar)
    {
        PlayerPrefs.SetInt("Avatar", avatar);

        /*
         1 Anne
         2 John
         3 Edward
         4 Jeireddin
         */
        Debug.Log("Se guardo el avatar: " + avatar);
    }
}
