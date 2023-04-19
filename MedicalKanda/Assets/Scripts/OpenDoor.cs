using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public AudioSource completedAudioSource;
    public AudioClip completedSound;
    public GameObject objectToChangeMaterial; // Her kan vi tilfoeje objectet vi vil aendre material i
    public Material greenMaterial; // Her vaelger vi hvilken material den skal aendres til

// Koden her aabner doeren
    public void Open() {
        leftDoor.transform.rotation *= Quaternion.Euler(0, -90, 0);
        rightDoor.transform.rotation *= Quaternion.Euler(0, 90, 0);
        completedAudioSource.PlayOneShot(completedSound);

        Renderer renderer = objectToChangeMaterial.GetComponent<Renderer>(); // Denne linje goer at naar man har aabnet doeren, saa aendre den material paa en Componenet
        if (renderer != null) {
            renderer.material = greenMaterial; // Hvis material ikke er sat eller = 0, saa aendrer den til Green
        }
    }
}
