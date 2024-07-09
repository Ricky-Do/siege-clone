using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    //MODIFIERS
    private float lookSpeed = 25f;
    private float moveSpeed = 20f;
    private float jumpHeight = 10f;
    private float maxVelocity = 10f;

    private float rotationX;
    [SerializeField] private GameObject droneCamera;
    private float gravity = -9.81f;
    private bool isGrounded;
    [SerializeField] private GameInput gameInput;
    private Rigidbody rigidbody;

    private void Awake(){
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start(){
        gameInput.OnJumpPerformed += GameInput_OnJumpPerformed;
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

        // Jumping
        // if (Input.GetKey(KeyCode.Space) && isGrounded)
        // {
        //     rigidbody.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
        // }

        if(!isGrounded){
            rigidbody.velocity += transform.up * gravity * Time.fixedDeltaTime;
        }

        //Limit the max speed of drone
        LimitVelocity();
    }

    private void GameInput_OnJumpPerformed(object sender, EventArgs e)
    {
        // Jumping
        if (isGrounded)
        {
            rigidbody.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
        }
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
        Vector2 inputVector = gameInput.GetDroneLookVector();

        // Get mouse input
        float mouseX = inputVector.x * lookSpeed * Time.deltaTime;
        float mouseY = inputVector.y * lookSpeed * Time.deltaTime;

        //Rotate the player camera on the X-axis to look up and down
		rotationX -= mouseY;
		rotationX = Mathf.Clamp(rotationX, -90f, 90f);
		droneCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
		
		transform.Rotate(0, mouseX, 0);
    }
}
