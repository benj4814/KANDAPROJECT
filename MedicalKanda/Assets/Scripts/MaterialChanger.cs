using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public GameObject objectToChange;
    public Material newMaterial;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                objectToChange.GetComponent<Renderer>().material = newMaterial;
                Debug.Log("Material changed!");
            }
        }
    }
}
