using UnityEngine;
using System.Collections;
using Unity.Burst.Intrinsics;
using UnityEngine.InputSystem;
using GLTFast.Schema;
using UnityEngine.SceneManagement;
using NUnit.Framework.Internal;
using JetBrains.Annotations;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    float xRotation = 0;

    public GameObject Gates;

    [Header("Движение")]

    public float walkSpeed = 10;

    public float crouchSpeed = 3;

    [Header("Камера")]

    public float mouseSensative = 4;

    public GameObject playerCamera;

    public float currentSpeed = 3;

    [Header("Прыгало")]

    public float jumpForce = 5; 

    public Vector3 GroundCheckOffset;

    public float groundCheckRadius = 0.3f;

    bool isGrounded = true;

    public LayerMask groundLayer;

    [Header("Подкат")]
    
    public float slideSpeed=5;

    public KeyCode slideKey = KeyCode.LeftControl;

    public string moveState = "Walk";

    public float slideTime = 2;

    public float  fadeSpeedDelta = 3;

    public Transform cameraRoot;

    public Vector3 cameraSlidePosition;

    Vector3 cameraInitPosition;

    Vector3 cameraYInitPosition;

    public float speedSlidePlus = 10;

    [Header("Quality of life")]

    public KeyCode restartKey = KeyCode.R;

    CapsuleCollider capsuleCollider;

    

    

    

    //public flopat jumpSlidePlus = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraInitPosition = cameraRoot.localPosition;
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        HandleJump();
        HandleSlide();
        if (Input.GetKeyDown(restartKey))
        {
            RestartCurrentScene();
        }
    }

    public void RestartCurrentScene()
    {
       
        SceneManager.LoadScene("Test");
    }

    void LateUpdate()
    {
        HandleMouse();
    }


    void FixedUpdate()
    {
        Move();
        CheckGround();
    }

    public void EnableBoost()
    {
        
    }
    void Move()
    {
        switch (moveState)
        {
            case "Walk":
                float moveX = Input.GetAxis("Horizontal");
                float moveZ = Input.GetAxis("Vertical");

                Vector3 move = transform.right * moveX + transform.forward * moveZ;

                rb.linearVelocity = new Vector3(move.x * currentSpeed, rb.linearVelocity.y, move.z * currentSpeed);
                break;
            case "Slide":
            float oldY = rb.linearVelocity.y;
            rb.linearVelocity = transform.forward * currentSpeed;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, oldY, rb.linearVelocity.z);
                break;
        }
        
    }


    
    void HandleMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensative;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensative;
        xRotation -= mouseY;

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        transform.Rotate(Vector3.up * mouseX);
    }
    

    IEnumerator SlideTimer()
    {
        yield return new WaitForSeconds(slideTime);

        while (true)
        {
            currentSpeed -= 1/fadeSpeedDelta;
            if (currentSpeed <= walkSpeed)
            {
                currentSpeed = walkSpeed;
                break;
                
;           }
            yield return new WaitForSeconds(1/30f);
        }
        moveState = "Walk";
        cameraRoot.localPosition = cameraInitPosition;
        capsuleCollider.height = 2;
        capsuleCollider.center = Vector3.zero;
        
    }
    
    void HandleSlide()
    {
        if (Input.GetKeyDown(slideKey))
        {
            moveState = "Slide";
            currentSpeed = slideSpeed;
            StartCoroutine("SlideTimer");
            cameraRoot.localPosition = cameraSlidePosition;
            capsuleCollider.height = 1;
            capsuleCollider.center = new Vector3 (capsuleCollider.center.x,-0.5f,capsuleCollider.center.z);
        }
        
        
    }

    void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            switch (moveState)
            {
                case "Walk":
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x,0,rb.linearVelocity.z);
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    break;

                case "Slide":
                    moveState ="Walk";
                    rb.linearVelocity = new Vector3(rb.linearVelocity.x,0,rb.linearVelocity.z);
                    rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);

                    currentSpeed += speedSlidePlus;
                    break;
            }
            
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

        if(isGrounded && moveState == "Walk" && currentSpeed != walkSpeed)
        {
            currentSpeed = walkSpeed;
        }
    }
}
