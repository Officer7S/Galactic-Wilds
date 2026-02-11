using UnityEngine;  
  
public class CameraFollow : MonoBehaviour  
{  
    public Transform target;     // Assign your player here  
    public Vector3 offset = new Vector3(0, 2, -5);  
    public float mouseSensitivity = 3f;  
    public float minY = -20f, maxY = 60f;  
  
    float yaw = 0f, pitch = 10f;  
  
    void LateUpdate()  
    {  
        // Mouse input  
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;  
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;  
        pitch = Mathf.Clamp(pitch, minY, maxY);  
  
        // Desired position  
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);  
        Vector3 desiredPos = target.position + rotation * offset;  
  
        // Wall check: if wall between player and camera, move camera closer  
        RaycastHit hit;  
        if (Physics.Linecast(target.position, desiredPos, out hit))  
        {  
            desiredPos = hit.point;  
        }  
  
        // Set camera position and look at player  
        transform.position = desiredPos;  
        transform.LookAt(target.position);  
    }  
}  
