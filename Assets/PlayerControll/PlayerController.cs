using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    float xRotation = 0;

    [Header("Движение")]

    public float walkSpeed = 10;

    public float crouchSpeed = 3;

    [Header("Камера")]

    public float mouseSensative = 4;

    public GameObject playerCamera;

    [Header("Прыгало")]

    public float jumpForce = 5; 

    public Vector3 GroundCheckOffset;

    public float groundCheckRadius = 0.3f;

    bool isGrounded = true;

    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouse();
        HandleJump();
    }


    void FixedUpdate()
    {
        Move();
        CheckGround();
    }
    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        rb.linearVelocity = new Vector3(move.x * walkSpeed, rb.linearVelocity.y, move.z * walkSpeed);
    }

    void HandleMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensative * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensative * Time.deltaTime;
        xRotation -= mouseY;

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x,0,rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + GroundCheckOffset,groundCheckRadius);
    }

    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(transform.position + GroundCheckOffset, groundCheckRadius, groundLayer);
    }
}
