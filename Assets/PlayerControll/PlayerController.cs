using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public GameObject playerCapsule;

    float xRotation = 0;

    public GameObject Gates;

    public GameObject defCanvas;

    public GameObject deadCanvas;

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

    [Header("крюк кошка")]

    public GameObject aimObject;

    public LayerMask hookMask;

    public float maxDistance = 5;

    public KeyCode HookKey = KeyCode.T;

    public Vector3 targetPosition;

    public float hookForce = 5;

    [Header("Quality of life")]

    public KeyCode restartKey = KeyCode.R;

    CapsuleCollider capsuleCollider;

    public float hookSpeed = 40;

    [Header("Life without quality")]

    public float MaxHealth = 100;

    public float CurrentHealth;

    public TMP_Text HealthText;

    

    

    

    

    //public flopat jumpSlidePlus = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraInitPosition = cameraRoot.localPosition;
        capsuleCollider = GetComponent<CapsuleCollider>();
        CurrentHealth = MaxHealth;
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
        HandleHook();
        HealthText.text = "HP" + CurrentHealth;

        if(CurrentHealth < 1)
        {
            defCanvas.SetActive(false);
            deadCanvas.SetActive(true);
            playerCapsule.SetActive(!false);
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
            case "Hook":
                rb.linearVelocity = (targetPosition - transform.position).normalized * hookSpeed;
            break;
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            CurrentHealth = CurrentHealth - 50;
        }
    }

    private void OnCollisionEnter(Collision colission)
    {
        if(moveState == "Hook")
        {
            moveState = "Walk";
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

    void HandleHook()
    {
        Ray hookRay = new Ray(Camera.main.transform.position,Camera.main.transform.forward);

        RaycastHit hitInfo;
        if(Physics.Raycast(hookRay,out hitInfo, maxDistance, hookMask))
        {
            if(hitInfo.collider.tag == "HookTo")
            {
                aimObject.SetActive(true);
                aimObject.transform.position = hitInfo.point;

                if (Input.GetKeyDown(HookKey))
                {
                    targetPosition = hitInfo.point;
                    moveState = "Hook";
                }
            }

            else if(hitInfo.collider.tag == "HookOt")
            {
                aimObject.SetActive(true);
                aimObject.transform.position = hitInfo.point;

                if (Input.GetKeyDown(HookKey))
                {
                    Rigidbody objRb = hitInfo.collider.GetComponent<Rigidbody>();
                    objRb.AddForce((transform.position - hitInfo.transform.position).normalized * hookForce, ForceMode.Impulse);
                }
            }
            
        }
        else
        {
            aimObject.SetActive(false);
        }
    }
}
