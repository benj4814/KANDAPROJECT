using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public AudioSource completedAudioSource;
    public AudioClip CompletedSound;

    public void Open() {
        leftDoor.transform.rotation *= Quaternion.Euler(0, -90, 0);
        rightDoor.transform.rotation *= Quaternion.Euler(0, 90, 0);
        completedAudioSource.PlayOneShot(CompletedSound);
    }
}
