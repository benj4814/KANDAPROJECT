using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungsTray : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lungs")
        {
            Debug.Log("Lungs accepted");
        }
        else
        {
            Debug.Log("Organ not accepted");
        }
    }
}
