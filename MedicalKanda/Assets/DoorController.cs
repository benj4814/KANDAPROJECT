using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float doorOpenAngle = 90f;
    public float smooth = 2f;
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
        if (isPlayerInsideZone && isOpen && Input.GetKeyDown(KeyCode.Mouse0)) {
            // Close the doors
            StartCoroutine(RotateDoors(leftDoor.transform, Quaternion.Euler(0, 0, 0), smooth));
            StartCoroutine(RotateDoors(rightDoor.transform, Quaternion.Euler(0, 0, 0), smooth));
            isOpen = false;
        } else if (isPlayerInsideZone && !isOpen && Input.GetKeyDown(KeyCode.Mouse0)) {
            // Open the doors
            StartCoroutine(RotateDoors(leftDoor.transform, Quaternion.Euler(0, doorOpenAngle, 0), smooth));
            StartCoroutine(RotateDoors(rightDoor.transform, Quaternion.Euler(0, -doorOpenAngle, 0), smooth));
            isOpen = true;
        }
    }

    IEnumerator RotateDoors(Transform door, Quaternion endRotation, float duration) {
        float t = 0f;
        Quaternion startRotation = door.rotation;
        while (t < duration) {
            t += Time.deltaTime;
            door.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        door.rotation = endRotation;
    }
}