using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private float lookSpeed = 500f;
    private float rotationX;
    private float moveSpeed = 20f;
    [SerializeField] private GameObject droneCamera;
    private float gravity = -9.81f;
    private bool isGrounded;
    private float jumpHeight = 50f;
    [SerializeField] private GameInput gameInput;
    private Rigidbody rigidbody;
    private float maxVelocity = 20f;

    private void Awake(){
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        HandleCameraMovement();
    }

    private void FixedUpdate(){
        HandleMovement();
    }

    private void HandleMovement(){
        Vector3 inputVector = gameInput.GetDroneMovementVectorNormalized();

        // Ground check
        isGrounded = Physics.Raycast(transform.position, -transform.up, 0.3f);

        //Calculate move vector
        Vector3 moveDirection = transform.TransformDirection(new Vector3(inputVector.x, 0f, inputVector.z) * moveSpeed);

        //Apply force to drone rb
        rigidbody.AddForce(moveDirection, ForceMode.Force);

        Debug.Log($"Drone is grounded: {isGrounded}");

        // Jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
        }

        //Limit the max speed of drone
        LimitVelocity();
    }

     private void LimitVelocity()
    {
        if (rigidbody.velocity.magnitude > maxVelocity)
        {
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxVelocity);
        }
    }

    /// <summary>
    /// Handles drone camera movement
    /// </summary>
    private void HandleCameraMovement()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        //Rotate the player camera on the X-axis to look up and down
		rotationX -= mouseY;
		rotationX = Mathf.Clamp(rotationX, -90f, 90f);
		droneCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
		
		transform.Rotate(0, mouseX, 0);
    }
}
