using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.Play();
    }
}