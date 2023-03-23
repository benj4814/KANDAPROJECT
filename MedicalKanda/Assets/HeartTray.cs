using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTray : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Heart")
        {
            Debug.Log("Heart accepted");
        }
        else
        {
            Debug.Log("Organ not accepted");
        }
    }
}