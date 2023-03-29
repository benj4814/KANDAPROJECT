using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.Play();
    }
}
