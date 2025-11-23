using StarterAssets;
using UnityEngine;

public class slideController : MonoBehaviour
{

    public FirstPersonController fpc;

    public duck duckController;

    CharacterController controller;

    public float slideSpeed = 37.5f;

    Rigidbody rb;

    public Transform cameraCrouchPlace;

    public Transform cameraTransform;

    Vector3 initialCameraPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpc = GetComponent<FirstPersonController>();
        controller = GetComponent<CharacterController>();
        duckController = GetComponent<duck>();
        rb = GetComponent<Rigidbody>();
        initialCameraPosition = cameraTransform.localPosition;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && duckController.isDuck == false)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(moveX, 0, moveY).normalized;
            Vector3 slideDirection = transform.TransformDirection(move);
            controller.enabled = false;
            rb.AddForce(slideDirection * slideSpeed, ForceMode.Impulse);
            Invoke("EnableFPC", 0.5f);
            cameraTransform.localPosition = cameraCrouchPlace.localPosition;
            
        }
    }

    void EnableFPC()
    {
        controller.enabled = true;
        cameraTransform.localPosition = initialCameraPosition;
    }
}
