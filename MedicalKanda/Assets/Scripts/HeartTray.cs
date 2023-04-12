using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTray : MonoBehaviour
{
    private TrayManager trayManager;

    private void Start()
    {
        trayManager = GameObject.FindObjectOfType<TrayManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Heart2")
        {
            Debug.Log("Heart accepted");
            trayManager.OrganPlacedCorrectly();
        }
        else
        {
            Debug.Log("Organ not accepted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Heart2")
        {
            trayManager.OrganRemoved();
        }
    }
}
