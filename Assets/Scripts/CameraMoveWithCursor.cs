using UnityEngine;
using Cinemachine;

public class CameraMoveWithCursor : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float cursorSensitivity = 1.0f;

    private Vector3 initialCameraPosition;

    private void Start()
    {
        // Store the initial camera position
        initialCameraPosition = virtualCamera.transform.position;
    }

    private void Update()
    {
        // Get cursor movement input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calculate the offset to apply to the camera's position
        Vector3 offset = new Vector3(mouseX, 0, mouseY) * cursorSensitivity;

        // Apply the offset to the initial camera position
        virtualCamera.transform.position = initialCameraPosition + offset;
    }
}