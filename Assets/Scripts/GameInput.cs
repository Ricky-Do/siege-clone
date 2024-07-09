using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GameInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    DroneInputActions droneInputActions;

    private void Awake(){
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        droneInputActions =  new DroneInputActions();
        droneInputActions.Drone.Disable();
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

    public Vector2 GetPlayerLookVector(){
        Vector2 inputVector = playerInputActions.Player.Look.ReadValue<Vector2>();

        return inputVector;
    }

    public Vector2 GetDroneLookVector(){
        Vector2 inputVector = droneInputActions.Drone.Look.ReadValue<Vector2>();

        return inputVector;
    }

    /// <summary>
    /// Gets normalized movement Vector3 from DroneInputActions
    /// </summary>
    /// <returns>Normalized Move Vector3</returns>
    public Vector3 GetDroneMovementVectorNormalized(){
        Vector3 inputVector = droneInputActions.Drone.Move.ReadValue<Vector3>();
        inputVector = inputVector.normalized;

        return inputVector;
    }

    public void TogglePlayerMovement(){
        if(playerInputActions.Player.enabled){
            playerInputActions.Player.Disable();
            droneInputActions.Drone.Enable();
        }
        else{
            playerInputActions.Player.Enable();
            droneInputActions.Drone.Disable();
        }
    }
}
