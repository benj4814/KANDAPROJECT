using UnityEngine;
using System.Collections;
 // Alle vores variabler
public class DoorController : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public float doorOpenAngle = 90f;
    public float smooth = 2f;
    private bool isOpen = false;
    private bool isPlayerInsideZone = false;
    public AudioSource doorAudioSource;
public AudioClip doorOpenSound;

// Koden her tjekker om vores "Player" er gaaet ind i vores TriggerZone. 
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player entered trigger zone.");
            isPlayerInsideZone = true;
        }
    }
// Koden her tjekker om vores "Player" er gaaet ud af vores TriggerZone igen
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player exited trigger zone.");
            isPlayerInsideZone = false;
        }
    }

    void Update() {
        if (isPlayerInsideZone && isOpen && Input.GetKeyDown(KeyCode.Mouse0)) {
            // Koden her goer, at hvis "Playeren" er inde i TriggerZonen, og doeren er aaben, saa lukker den hvis man tykker paa Mouse0
            StartCoroutine(RotateDoors(leftDoor.transform, Quaternion.Euler(0, 0, 0), smooth));
            StartCoroutine(RotateDoors(rightDoor.transform, Quaternion.Euler(0, 0, 0), smooth));
            isOpen = false;
            doorAudioSource.PlayOneShot(doorOpenSound); // Denne kode afspiller en lyd naar man klikker paa doeren
        } else if (isPlayerInsideZone && !isOpen && Input.GetKeyDown(KeyCode.Mouse0)) {
            // Koden her goer, at hvis "Playeren" er inde i TriggerZonen, og doeren er lukket, saa aabner den hvis man tykker paa Mouse0
            StartCoroutine(RotateDoors(leftDoor.transform, Quaternion.Euler(0, doorOpenAngle, 0), smooth));
            StartCoroutine(RotateDoors(rightDoor.transform, Quaternion.Euler(0, -doorOpenAngle, 0), smooth));
            isOpen = true;

            doorAudioSource.PlayOneShot(doorOpenSound); // Denne kode afspiller en lyd naar man klikker paa doeren
        }
    }
// Koden har rotere doeren fra en nuvaerende location til en specifik end location
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