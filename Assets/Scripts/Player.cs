using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float lookSpeed = 1f;
    private float rotationX;
    private float moveSpeed = 3f;
    [SerializeField] private GameObject playerCamera;


    private void Start(){
        rigidbody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update(){
        HandleMovement();
        HandleCameraMovement();
    }

    private void HandleMovement(){
        Vector3 inputVector = new Vector3(0, 0 , 0);

        //WASD movement
        if(Input.GetKey(KeyCode.W)){
            inputVector += transform.forward;
        }
        if(Input.GetKey(KeyCode.S)){
            inputVector -= transform.forward;
        }
        if(Input.GetKey(KeyCode.A)){
            inputVector -= transform.right;
        }
        if(Input.GetKey(KeyCode.D)){
            inputVector += transform.right;
        }

        Vector3 moveDirection = inputVector.normalized * moveSpeed;

        //Apply force to player in the direction of movement
        rigidbody.AddForce(moveDirection);

        //If player is not pressing movement keys, stop player momentum
        if(inputVector == Vector3.zero){
            rigidbody.velocity = Vector3.zero;
        }
    }

    /// <summary>
    /// Handles player camera movement
    /// </summary>
    private void HandleCameraMovement()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        //Rotate the player camera on the X-axis to look up and down
		rotationX -= mouseY;
		rotationX = Mathf.Clamp(rotationX, -90f, 90f);
		playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
		
		transform.Rotate(0, mouseX, 0);
    }
}
