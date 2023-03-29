using UnityEngine;

public class DoorSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Detect when the "E" key is released
        if (Input.GetKeyUp(KeyCode.E))
        {
            // Play the AudioClip attached to the AudioSource
            audioSource.Play();
        }
    }
}