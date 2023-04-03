using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiverTray : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Liver")
        {
            Debug.Log("Liver accepted");
        }
        else
        {
            Debug.Log("Organ not accepted");
        }
    }
}
