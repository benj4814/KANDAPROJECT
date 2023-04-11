using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganSnapping : MonoBehaviour
{
    public GameObject organ;
    public GameObject organPosition;

    private bool isSnapped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == organ)
        {
            // Set isSnapped to true when the heart enters the trigger zone
            isSnapped = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == organ)
        {
            // Set isSnapped to false when the heart exits the trigger zone
            isSnapped = false;
        }
    }

    private void Update()
    {
        if (isSnapped && Input.GetMouseButtonUp(0))
        {
            // Snap the heart to the position when it is in the trigger zone and the left mouse button is released
            organ.transform.position = organPosition.transform.position;
            organ.transform.rotation = organPosition.transform.rotation;
            organ.GetComponent<Rigidbody>().isKinematic = true;
            isSnapped = true;
        }
        else if (!isSnapped)
        {
            // If the heart is not in the trigger zone, allow it to be dragged by the player
            organ.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
