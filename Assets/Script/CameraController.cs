using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float distance = 5f;
    [SerializeField] private float height = 2f;
    [SerializeField] private float side;
    [SerializeField] private Vector2 clampMinMax;
    
    private float rotationX = 0f;
    private float rotationY = 0f;
    
    void Start()
    {
        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        // Update rotation
        rotationY += mouseX;
        rotationX -= mouseY;
        
        // Clamp vertical rotation 
        rotationX = Mathf.Clamp(rotationX, clampMinMax.x, clampMinMax.y);
        
        // Calculate camera position around player
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);
        
        // Set camera position and look at player
        transform.position = playerTransform.position + offset;
        // Look slightly to the right of the player
        transform.LookAt(playerTransform.position + Vector3.up * height + playerTransform.right * side);
    }
}