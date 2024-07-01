using UnityEngine;
using Cinemachine;

public class CameraToggle : MonoBehaviour
{
    [SerializeField] private Transform playerVirtualCamera; // Assign the Player Virtual Camera in the Inspector
    [SerializeField] private Transform droneVirtualCamera; // Assign the Drone Virtual Camera in the Inspector
    private CinemachineVirtualCamera playerCamera;
    private CinemachineVirtualCamera droneCamera;

    private void Start()
    {
       playerCamera = playerVirtualCamera.GetComponent<CinemachineVirtualCamera>();
       droneCamera = droneVirtualCamera.GetComponent<CinemachineVirtualCamera>();

        // Ensure only the player camera is active at the start
        playerCamera.Priority = 10;
        droneCamera.Priority = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Press 'C' to toggle cameras
        {
            ToggleCameras();
        }
    }

    private void ToggleCameras()
    {
        if (playerCamera.Priority > droneCamera.Priority)
        {
            playerCamera.Priority = 0;
            droneCamera.Priority = 10;
        }
        else
        {
            playerCamera.Priority = 10;
            droneCamera.Priority = 0;
        }
    }
}