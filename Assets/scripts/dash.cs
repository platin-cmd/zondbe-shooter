using StarterAssets;
using UnityEngine;

public class slide : MonoBehaviour
{

    public FirstPersonController fpc;

    public duck duckController;

    CharacterController controller;

    public float slideSpeed = 37.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpc = GetComponent<FirstPersonController>();
        controller = GetComponent<CharacterController>();
        duckController = GetComponent<duck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && duckController.isDuck == false)
        {
            Vector3 slideDirection = fpc.transform.forward;
            controller.Move(slideDirection * slideSpeed * Time.deltaTime);
        }
    }
}