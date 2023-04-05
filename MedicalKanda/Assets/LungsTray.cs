using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungsTray : MonoBehaviour
{
    private TrayManager trayManager;

    private void Start()
    {
        trayManager = GameObject.FindObjectOfType<TrayManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lungs")
        {
            Debug.Log("Lungs accepted");
            trayManager.OrganPlacedCorrectly();
        }
        else
        {
            Debug.Log("Organ not accepted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Lungs")
        {
            trayManager.OrganRemoved();
        }
    }
}
