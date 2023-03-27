using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // The amount to move the GameObject on the X-axis
    public float moveAmount = 1f;

    // Open the door
    public void Open()
    {
        // Get the current position of the GameObject
        Vector3 currentPosition = transform.position;

        // Calculate the new position with the X-axis value increased by moveAmount
        Vector3 newPosition = new Vector3(currentPosition.x + moveAmount, currentPosition.y, currentPosition.z);

        // Move the GameObject to the new position
        transform.position = newPosition;

        Debug.Log("Door opened");
    }
}
