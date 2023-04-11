using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomCursor : MonoBehaviour
{
    public TMP_InputField input;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            input.Select();
        }
    }
}
