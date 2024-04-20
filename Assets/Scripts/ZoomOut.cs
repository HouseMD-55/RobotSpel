using UnityEngine;

public class CameraSwitchAndRotate : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cam2;
    public float sensitivity = 2.0f; // Adjust the sensitivity of mouse movement

    private bool isCamera2Active = false;
    private float rotationX = 0.0f;

    void Start()
    {
        // Ensure only the main camera is initially active
        mainCamera.enabled = true;
        cam2.enabled = false;
    }

    void Update()
    {
        // Toggle camera switch when the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleCamera();
        }

        // If camera 2 is active, allow looking around with the mouse
        if (isCamera2Active)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -25f, 40f);

            cam2.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    void ToggleCamera()
    {
        isCamera2Active = !isCamera2Active;
        mainCamera.enabled = !isCamera2Active;
        cam2.enabled = isCamera2Active;

        // Reset rotation when switching cameras
        rotationX = 0.0f;
        transform.rotation = Quaternion.identity;
    }
}
