using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isInteractable = false;
    public GameObject uiCanvas;
    public Transform interactionTransform;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isInteractable = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && isInteractable)
            {
                isInteractable = false;
                uiCanvas.SetActive(false);
            }
        }
    }
}
