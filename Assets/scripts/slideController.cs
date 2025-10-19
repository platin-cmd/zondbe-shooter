using StarterAssets;
using UnityEngine;

public class slideController : MonoBehaviour
{

    public FirstPersonController fpc;

    public duck duckController;

    CharacterController controller;

    public float slideSpeed = 37.5f;

    Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpc = GetComponent<FirstPersonController>();
        controller = GetComponent<CharacterController>();
        duckController = GetComponent<duck>();
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && duckController.isDuck == false)
        {
            Vector3 slideDirection = fpc.transform.forward;
            controller.enabled = false;
            rb.AddForce(slideDirection * slideSpeed, ForceMode.Impulse);
            Invoke("EnableFPC", 0.5f);
        }
    }

    void EnableFPC()
    {
        controller.enabled = true;
    }
}
