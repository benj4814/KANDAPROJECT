using UnityEngine;

public class PlaySoundOnMouseDown : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.Play();
    }
}
