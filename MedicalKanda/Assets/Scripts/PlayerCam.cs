using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX = 100f;
    public float sensY = 100f;

    private float yRotation = 0f;
    private float xRotation = 0f;

    public Transform orientation;

    void FixedUpdate()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // apply rotation to camera
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // apply orientation rotation to player
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}