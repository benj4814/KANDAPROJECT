using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganTray : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Heart")
        {
            Debug.Log("Organ accepted");
        }
        else
        {
            Debug.Log("Organ not accepted");
        }
    }
}
