using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    public InputField name;
    public InputField age;

    // Use this for initialization
    void Start () {

        //Comentar linea de abajo para no resetear prefabs
        PlayerPrefs.SetInt("isFirstTime", 0);

        if (!PlayerPrefs.HasKey("isFirstTime") || PlayerPrefs.GetInt("isFirstTime") != 1)
        {
            // Show your prologue here.

            //Salvar datos 
         
        }
        else
        {
            SceneManager.LoadScene("MainMenu");

        }
        // Now set the value of isFirstTime to be false in the PlayerPrefs.
        PlayerPrefs.SetInt("isFirstTime", 1);
        PlayerPrefs.Save();

    }
	
	public void setget () {
        PlayerPrefs.SetString("Nombre", name.text);
        Debug.Log("Se guardo el nombre: " + name.text);

        PlayerPrefs.SetString("Edad", age.text);

        Debug.Log("Se guardo la edad: " + age.text);

    }
     
        
   

}
