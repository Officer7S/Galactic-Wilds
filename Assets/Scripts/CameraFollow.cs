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
  
        // Calculate rotation  
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);  
  
        // Desired position  
        Vector3 desiredPos = target.position + rotation * offset;  
  
        // Wall check: only run if we have an offset (3rd person)  
        if (offset != Vector3.zero)  
        {  
            RaycastHit hit;  
            if (Physics.Linecast(target.position, desiredPos, out hit))  
            {  
                desiredPos = hit.point;  
            }  
        }  
  
        // Set camera position  
        transform.position = desiredPos;  
  
        // LOOK AT LOGIC:  
        // If offset is zero (1st person), look forward using our calculated rotation.  
        // If offset is not zero (3rd person), look at the player.  
        if (offset == Vector3.zero)  
        {  
            transform.rotation = rotation;  
        }  
        else  
        {  
            transform.LookAt(target.position);  
        }  
    }  
}  
