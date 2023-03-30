using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("Player entered trigger zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            Debug.Log("Player exited trigger zone");
        }
    }

    private void OnMouseDown()
    {
        if (isPlayerInside)
        {
            audioSource.Play();
            Debug.Log("Playing door sound");
        }
        else
        {
            Debug.Log("Player is not inside trigger zone");
        }
    }
}
