using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpHeight = 2f;

    private float _verticalRotation = 0f;
    private float _verticalVelocity = 0f;
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Handle jumping
        if (_controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            _verticalVelocity = jumpHeight;
        }

        // Apply gravity
        _verticalVelocity += Physics.gravity.y * Time.deltaTime;
        movement.y = _verticalVelocity;

        // Handle mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity;

        _verticalRotation += mouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Move character
        _controller.Move(transform.rotation * movement * Time.deltaTime);
    }
}