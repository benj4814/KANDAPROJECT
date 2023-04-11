using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public Rigidbody rb;

    // Drag and drop the player object with the Rigidbody component to this field in the inspector
    public GameObject playerObject;

    private void Start()
    {
        // Get the Rigidbody component from the playerObject
        rb = playerObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.position = cameraPosition.position;
        rb.velocity = Vector3.zero;
    }
}