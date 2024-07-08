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
        droneInputActions.Drone.Enable();
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

    //TO DO: MIGHT NEED TO GET NORMALISED VALUE LATER
    public Vector2 GetLookVector(){
        Vector2 inputVector = playerInputActions.Player.Look.ReadValue<Vector2>();

        Debug.Log(inputVector);

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
        if(playerInputActions.Player.Move.enabled){
            playerInputActions.Player.Move.Disable();
        }
        else{
            playerInputActions.Player.Move.Enable();
        }
    }
}
