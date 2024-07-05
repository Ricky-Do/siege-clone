using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private float lookSpeed = 1f;
    private float rotationX;
    private float moveSpeed = 10f;
    [SerializeField] private GameObject droneCamera;
    private float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;
    private float jumpHeight = 2f;
    [SerializeField] private GameInput gameInput;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        HandleMovement();
        HandleCameraMovement();
    }

    private void HandleMovement(){
        Vector3 inputVector = gameInput.GetDroneMovementVectorNormalized();

        // Jumping
        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        // }

        // Ground check
        isGrounded = Physics.Raycast(transform.position, new Vector3(0, -1f, 0), 0.3f);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Ensure the player stays grounded
        }

        Vector3 moveDirection = transform.TransformDirection(new Vector3(inputVector.x, 0f, inputVector.z) * moveSpeed);

        //Move the player
        //controller.Move(moveDirection * Time.deltaTime);

        //Apply gravity
        velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);

    }

    /// <summary>
    /// Handles drone camera movement
    /// </summary>
    private void HandleCameraMovement()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        //Rotate the player camera on the X-axis to look up and down
		rotationX -= mouseY;
		rotationX = Mathf.Clamp(rotationX, -90f, 90f);
		droneCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
		
		transform.Rotate(0, mouseX, 0);
    }
}
