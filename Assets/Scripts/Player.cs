using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float moveSpeed = 3f;


    private void Start(){
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update(){
        HandleMovement();
    }

    private void HandleMovement(){
        Vector3 inputVector = new Vector3(0, 0 , 0);

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

        Debug.Log(inputVector);

        rigidbody.AddForce(inputVector * moveSpeed);
    }
}
