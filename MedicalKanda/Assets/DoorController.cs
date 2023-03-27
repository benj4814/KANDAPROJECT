using UnityEngine;

public class DoorController : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    private bool isOpen = false;
    private bool isPlayerInsideZone = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player entered trigger zone.");
            isPlayerInsideZone = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player exited trigger zone.");
            isPlayerInsideZone = false;
        }
    }

    void Update() {
        if (isPlayerInsideZone && isOpen && Input.GetKeyDown(KeyCode.E)) {
            // Close the doors
            leftDoor.transform.rotation *= Quaternion.Euler(0, 90, 0);
            rightDoor.transform.rotation *= Quaternion.Euler(0, -90, 0);
            isOpen = false;
        } else if (isPlayerInsideZone && !isOpen && Input.GetKeyDown(KeyCode.E)) {
            // Open the doors
            leftDoor.transform.rotation *= Quaternion.Euler(0, -90, 0);
            rightDoor.transform.rotation *= Quaternion.Euler(0, 90, 0);
            isOpen = true;
        }
    }
}