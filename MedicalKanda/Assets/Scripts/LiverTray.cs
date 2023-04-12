using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiverTray : MonoBehaviour
{
    private TrayManager trayManager;

    private void Start()
    {
        trayManager = GameObject.FindObjectOfType<TrayManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Liver2")
        {
            Debug.Log("Liver accepted");
            trayManager.OrganPlacedCorrectly();
        }
        else
        {
            Debug.Log("Organ not accepted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Liver2")
        {
            trayManager.OrganRemoved();
        }
    }
}
