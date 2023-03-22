using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTray : MonoBehaviour
{
    public GameObject heart;
    public GameObject liver;
    public GameObject lungs;
    public AudioClip successSound;

    private bool heartPlaced;
    private bool liverPlaced;
    private bool lungsPlaced;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == heart)
        {
            heartPlaced = true;
        }
        else if (other.gameObject == liver)
        {
            liverPlaced = true;
        }
        else if (other.gameObject == lungs)
        {
            lungsPlaced = true;
        }

        if (heartPlaced && liverPlaced && lungsPlaced)
        {
            audioSource.PlayOneShot(successSound);
        }
    }
}