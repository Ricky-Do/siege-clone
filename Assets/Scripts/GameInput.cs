using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    DroneInputActions droneInputActions;
    public event EventHandler OnJumpPerformed;
    public event EventHandler OnRunPerformed;
    public event EventHandler OnRunCanceled;
    public static GameInput Instance {get; private set;}

    private void Awake(){
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        droneInputActions =  new DroneInputActions();
        droneInputActions.Drone.Disable();

        droneInputActions.Drone.Jump.performed += DroneJump_performed;
        playerInputActions.Player.Run.performed += PlayerRun_performed;
        playerInputActions.Player.Run.canceled += PlayerRun_canceled;
    }

    /// <summary>
    /// Trigger DroneJump event when player
    /// </summary>
    /// <param name="context"></param>
    private void DroneJump_performed(InputAction.CallbackContext context)
    {
        OnJumpPerformed?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerRun_performed(InputAction.CallbackContext context)
    {
        OnRunPerformed?.Invoke(this, EventArgs.Empty);
    }
    private void PlayerRun_canceled(InputAction.CallbackContext context){
        OnRunCanceled?.Invoke(this, EventArgs.Empty);
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