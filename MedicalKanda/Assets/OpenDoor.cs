using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public AudioSource completedAudioSource;
    public AudioClip completedSound;
    public GameObject objectToChangeMaterial;
    public Material greenMaterial;

    public void Open() {
        leftDoor.transform.rotation *= Quaternion.Euler(0, -90, 0);
        rightDoor.transform.rotation *= Quaternion.Euler(0, 90, 0);
        completedAudioSource.PlayOneShot(completedSound);

        Renderer renderer = objectToChangeMaterial.GetComponent<Renderer>();
        if (renderer != null) {
            renderer.material = greenMaterial;
        }
    }
}
