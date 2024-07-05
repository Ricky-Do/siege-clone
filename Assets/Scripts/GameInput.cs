using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    private void Awake(){
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Move.Enable();
    }

    /// <summary>
    /// Gets normalized movement Vector3 from PlayerInputActions
    /// </summary>
    /// <returns>Normalized Move Vector3</returns>
    public Vector3 GetMovementVectorNormalized(){
        Vector3 inputVector = playerInputActions.Player.Move.ReadValue<Vector3>();
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
