using UnityEngine;


// Naar man klikker paa det GameObject der har faaet scriptet, saa afspilles AudioSourcen paa GameObjectet.
public class PlaySoundOnMouseDown : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnMouseDown()
    {
        audioSource.Play();
    }
}
