using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject objectToLookAt; // Her er objectet som "playeren" skal kigge paa
    private bool inTriggerZone = false;
    private bool doorOpened = false;
    private Collider doorCollider;


// Koden her fra til linje 34 tjekker om vores "player" er inde i vores TriggerZone eller ej
    void Start()
    {
        doorCollider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = true;
            Debug.Log("Player entered trigger zone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = false;
            Debug.Log("Player exited trigger zone.");
        }
    }

    void Update()
    {
        // Denne linje tjekker om Mouse0 bliver klikket imens vores "Player" er inde i TriggerZoenen og kigger paa det korrekte GameObject og doeren er lukket
        if (inTriggerZone && Input.GetMouseButtonDown(0) && IsLookingAtObject() && !doorOpened)
        {
            // Denne goer at doeren aabnes til en bestemt rotation.
            transform.Rotate(new Vector3(0f, -90f, 0f));
            Debug.Log("Door opened.");
            
            // Her bliver doeren sat til at vaere aaben
            doorOpened = true;
            doorCollider.enabled = false;
        }
    }

    private bool IsLookingAtObject()
    {
        // Her tjekker den om vores MainCamera kigger paa vores GameObject
        Vector3 direction = objectToLookAt.transform.position - Camera.main.transform.position;

        // Koden her tjekker om ObjectToLookAt er cirka det samme som CameraMainTransformPosition
        return Vector3.Dot(direction.normalized, Camera.main.transform.forward) > 0.85f;
    }
}
