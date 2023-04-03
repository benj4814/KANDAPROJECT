using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject door; // assign the door object to this in the inspector
    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // the player has entered the trigger zone
            if (Input.GetMouseButtonDown(0)) // check if the player has clicked the left mouse button
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == door)
                {
                    // the player is pointing at the door and clicked the left mouse button
                    if (!isOpen)
                    {
                        // open the door by rotating it 90 degrees around its y-axis
                        door.transform.Rotate(0f, 90f, 0f);
                        isOpen = true;
                    }
                }
            }
        }
    }
}
