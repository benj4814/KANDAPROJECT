using UnityEngine;


public class HeartPositioning : MonoBehaviour
{
    public GameObject heart;
    public Transform correctPosition;

    private DragObject dragObjectScript;

    private void Start()
    {
        // Get the DragObject script attached to the heart object
        dragObjectScript = heart.GetComponent<DragObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is the heart object
        if (other.gameObject == heart)
        {
            // Disable the DragObject script so the player can't move the heart
            dragObjectScript.enabled = false;

            // Move the heart to the correct position
            heart.transform.position = correctPosition.position;
            heart.transform.rotation = correctPosition.rotation;
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider that exited the trigger is the heart object
        if (other.gameObject == heart)
        {
            // Enable the DragObject script so the player can move the heart again
            dragObjectScript.enabled = true;
        }
    }
}
