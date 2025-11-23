using System;
using StarterAssets;
using UnityEngine;

public class slide : MonoBehaviour
{

    public FirstPersonController fpc;

    public duck duckController;

    CharacterController controller;

    public float slideSpeed = 37.5f;

    public bool isDashing = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpc = GetComponent<FirstPersonController>();
        controller = GetComponent<CharacterController>();
        duckController = GetComponent<duck>();
    }

    void OnCollisionEnter(Collision collision)
    {

        print("Collission");
        if(collision.gameObject.CompareTag("enemy") )
        {
            print("Смерть зомби!!!11!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && duckController.isDuck == false && !isDashing)
        {
            Dash();

        }
    }

    public void Dash()
    {
        print("double dash");
        Vector3 slideDirection = fpc.transform.forward;
            controller.Move(slideDirection * slideSpeed * Time.deltaTime);
            isDashing = true;
            Invoke("ResetDash",0.5f);

    }

    void ResetDash()
    {
        isDashing = false;
    }
}