using UnityEngine;  
  
public class PlayerMovement : MonoBehaviour  
{  
    public float speed = 5f;          // Movement speed  
    public float jumpForce = 7f;      // Jump strength  
    private Rigidbody rb;  
    private bool isGrounded = true;   // Checks if player is on the ground  
    public Transform cam; // Assign your camera in the Inspector  
    public bool isJumpBoosted = false; 

    void Start()  
    {  
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component  
    }  
  
    void Update()  
    {  
        float x = Input.GetAxis("Horizontal");  
        float z = Input.GetAxis("Vertical");  
  
        // Get camera directions, ignore y axis  
        Vector3 camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;  
        Vector3 camRight = Vector3.Scale(cam.right, new Vector3(1, 0, 1)).normalized;  
  
        // Movement relative to camera  
        Vector3 move = (camForward * z + camRight * x) * speed * Time.deltaTime;  
        transform.Translate(move, Space.World);  

  
        // Jump if on ground and space pressed  
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)  
        {  
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  
            isGrounded = false;  
        }  
    }  
  
    void OnCollisionEnter(Collision collision)  
    {  
        // If we touch the ground, allow jumping again  
        if (collision.gameObject.CompareTag("Ground"))  
        {  
            isGrounded = true;  
        }  
    }  
}  
