using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CustomCursor : MonoBehaviour, IPointerClickHandler
{
    public TMP_InputField input;

    private bool inputSelected = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!inputSelected)
        {
            inputSelected = true;
            input.Select();
        }
    }

    public void OnInputDeselect()
    {
        inputSelected = false;
    }
}
