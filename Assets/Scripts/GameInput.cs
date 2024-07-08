using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    DroneInputActions droneInputActions;

    private void Awake(){
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Move.Enable();

        droneInputActions =  new DroneInputActions();
        droneInputActions.Drone.Move.Enable();
    }

    /// <summary>
    /// Gets normalized movement Vector3 from PlayerInputActions
    /// </summary>
    /// <returns>Normalized Move Vector3</returns>
    public Vector3 GetPlayerMovementVectorNormalized(){
        Vector3 inputVector = playerInputActions.Player.Move.ReadValue<Vector3>();
        inputVector = inputVector.normalized;

        return inputVector;
    }

    /// <summary>
    /// Gets normalized movement Vector3 from DroneInputActions
    /// </summary>
    /// <returns>Normalized Move Vector3</returns>
    public Vector3 GetDroneMovementVectorNormalized(){
        Vector3 inputVector = droneInputActions.Drone.Move.ReadValue<Vector3>();
        inputVector = inputVector.normalized;

        Debug.Log($"Drone Vector: {inputVector}");
        return inputVector;
    }

    public void TogglePlayerMovement(){
        if(playerInputActions.Player.Move.enabled){
            playerInputActions.Player.Move.Disable();
        }
        else{
            playerInputActions.Player.Move.Enable();
        }
    }
}
