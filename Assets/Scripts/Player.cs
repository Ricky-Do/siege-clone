using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //MODIFIERS
    private float lookSpeed = 20f;
    private float moveSpeed = 10f;
    private float jumpHeight = 2f;
    private float runSpeed = 1f;

    [SerializeField] private GameObject playerCamera;
    private CharacterController controller;
    private float gravity = -9.81f;
    private Vector3 velocity;
    private bool isGrounded;
    private float rotationX;
    [SerializeField] private GameInput gameInput;

    private void Start(){

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();

        gameInput.OnRunPerformed += GameInput_OnRunPerformed;
        gameInput.OnRunCanceled += GameInput_OnRunCanceled;
    }

    private void Update(){
        HandleMovement();
        HandleCameraMovement();
    }

    private void HandleMovement(){
        Vector3 inputVector = gameInput.GetPlayerMovementVectorNormalized();
        
        //Run
        // if(Input.GetKeyDown(KeyCode.LeftShift)){
        //     runSpeed = 1.25f;
        // }
        // if(Input.GetKeyUp(KeyCode.LeftShift)){
        //     runSpeed = 1f;
        // }

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

        Vector3 moveDirection = transform.TransformDirection(new Vector3(inputVector.x, 0f, inputVector.z) * moveSpeed * runSpeed);

        //Move the player
        controller.Move(moveDirection * Time.deltaTime);

        //Apply gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    private void GameInput_OnRunPerformed(object sender, EventArgs e){
        runSpeed = 1.25f;
    }
    private void GameInput_OnRunCanceled(object sender, EventArgs e){
        runSpeed = 1f;
    }

    /// <summary>
    /// Handles player camera movement
    /// </summary>
    private void HandleCameraMovement()
    {
        Vector2 inputVector = gameInput.GetPlayerLookVector();

        // Get mouse input
        float mouseX = inputVector.x * lookSpeed * Time.deltaTime;
        float mouseY = inputVector.y * lookSpeed * Time.deltaTime;

        //Rotate the player camera on the X-axis to look up and down
		rotationX -= mouseY;
		rotationX = Mathf.Clamp(rotationX, -90f, 90f);
		playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
		
		transform.Rotate(0, mouseX, 0);
    }
}
