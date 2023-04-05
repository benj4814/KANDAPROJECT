using System.Collections;
using System.Collections.Generic;
// Attach this script to the door gameObject
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject objectToLookAt; // drag the object that the player needs to look at here in the inspector
    private bool inTriggerZone = false;
    private bool doorOpened = false;
    private Collider doorCollider;

    void Start()
    {
        doorCollider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = true;
            Debug.Log("Player entered trigger zone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = false;
            Debug.Log("Player exited trigger zone.");
        }
    }

    void Update()
    {
        // Check for left mouse button click and player in trigger zone and looking at the objectToLookAt and door not already opened
        if (inTriggerZone && Input.GetMouseButtonDown(0) && IsLookingAtObject() && !doorOpened)
        {
            // Rotate the door 90 degrees on the Y axis
            transform.Rotate(new Vector3(0f, -90f, 0f));
            Debug.Log("Door opened.");
            
            // Set the door as opened and disable its collider
            doorOpened = true;
            doorCollider.enabled = false;
        }
    }

    private bool IsLookingAtObject()
    {
        // Get the direction from the camera to the objectToLookAt
        Vector3 direction = objectToLookAt.transform.position - Camera.main.transform.position;

        // Check if the direction vector is roughly equal to the camera's forward vector
        return Vector3.Dot(direction.normalized, Camera.main.transform.forward) > 0.85f;
    }
}
