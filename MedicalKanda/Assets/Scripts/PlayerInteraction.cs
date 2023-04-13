using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float interactionDistance; // How far the player can interact with objects
    public LayerMask interactableLayer; // The layer that contains interactable objects
    public GameObject cursor; // The cursor object to hide/show when interacting
    public GameObject book; // The cursor object to hide/show when interacting

    private InteractableObject currentInteractableObject = null; // The current object the player is interacting with
    private bool isInteracting = false; // Flag to check if the player is currently interacting with an object
    private Vector3 originalPosition; // The original position of the player before interacting
    private Quaternion originalRotation; // The original rotation of the player before interacting

    private void Update()
    {
        if (!isInteracting) // If the player is not currently interacting with an object
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance, interactableLayer)) // Cast a ray forward to check for interactable objects within range
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
                if (interactableObject) // If an interactable object is hit by the raycast
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0)) // If the player presses the interact button
                    {
                        isInteracting = true; // Set the interaction flag to true
                        currentInteractableObject = interactableObject; // Set the current interactable object
                        currentInteractableObject.isInteractable = true; // Set the interactable flag on the object
                        currentInteractableObject.uiCanvas.SetActive(true); // Show the UI canvas for the object
                        cursor.SetActive(false); // Hide the cursor
                        book.SetActive(false); // Hide the book
                        originalPosition = transform.position; // Save the original position of the player
                        originalRotation = transform.rotation; // Save the original rotation of the player
                        transform.position = currentInteractableObject.interactionTransform.position; // Move the player to the interaction position of the object
                        transform.rotation = currentInteractableObject.interactionTransform.rotation; // Rotate the player to the interaction rotation of the object
                    }
                }
            }
        }
        else // If the player is currently interacting with an object
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && currentInteractableObject) // If the player presses the interact button again
            {
                isInteracting = false; // Set the interaction flag to false
                currentInteractableObject.isInteractable = false; // Set the interactable flag on the object to false
                currentInteractableObject.uiCanvas.SetActive(false); // Hide the UI canvas for the object
                cursor.SetActive(true); // Show the cursor
                book.SetActive(true); // Show the book
                transform.position = originalPosition; // Move the player back to the original position
                transform.rotation = originalRotation; // Rotate the player back to the original rotation
                currentInteractableObject = null; // Set the current interactable object to null
            }
        }
    }
    private void LateUpdate()
    {
        if (isInteracting) // If the player is currently interacting with an object
        {
            transform.position = currentInteractableObject.interactionTransform.position; // Set the player's position to the interaction position of the object
            transform.rotation = currentInteractableObject.interactionTransform.rotation; // Set the player's rotation to the interaction rotation of the object
        }
    }
}

