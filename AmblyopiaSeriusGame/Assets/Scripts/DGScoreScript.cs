using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DGScoreScript : MonoBehaviour {

    public float currentTime;
    public float maxTime;
    public Slider timeBar;

	// Use this for initialization
	void Start () {
	}

    public void RestartTimer(float newTime)
    {
        maxTime = newTime;
        currentTime = newTime;
        timeBar.value = CalculateTimePercentage();
    }

    // Update is called once per frame
    void Update () {
        currentTime -= Time.deltaTime;
        timeBar.value = CalculateTimePercentage();
        if (currentTime <= 0)
            Die();
	}

    private void Die()
    {
        Debug.Log("Tiempo Agotado");
    }

    private float CalculateTimePercentage()
    {
        return currentTime / maxTime;
    }
}
