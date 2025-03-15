using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;
    public float gravity = 9.8f; // Gravity force
    public float jumpHeight = 2f; // Jump height

    private CharacterController controller;
    private float rotationX = 0f;
    private Vector3 velocity; // Stores downward velocity

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to game window
    }

    void Update()
    {
        // Player Movement
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical"); // W/S or Up/Down
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Gravity
        if (!controller.isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.Space)) // Jumping
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        controller.Move(velocity * Time.deltaTime);
    }
}

