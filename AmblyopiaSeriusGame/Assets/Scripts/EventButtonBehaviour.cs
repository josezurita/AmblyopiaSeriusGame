using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject text;
    public Material normalMaterial;
    public Material hoverMaterial;
    public Material disabledMaterial;
    private bool isDisabled = false;
    private TextMeshProUGUI textMeshProGUI;
    private TextMeshPro textMeshPro;

    // Use this for initialization
    void Awake () {
        textMeshProGUI = text.GetComponent<TextMeshProUGUI>();
        textMeshPro = text.GetComponent<TextMeshPro>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isDisabled)
        {
            textMeshProGUI.fontSharedMaterial = hoverMaterial;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isDisabled)
        {
            textMeshProGUI.fontSharedMaterial = normalMaterial;
        }
    }

    public void toogleDisabled()
    {
        if (isDisabled)
        {
            textMeshProGUI.fontSharedMaterial = normalMaterial;
            isDisabled = false;
        }
        else
        {
            textMeshProGUI.fontSharedMaterial = disabledMaterial;
            isDisabled = true;
        }
    }
}
