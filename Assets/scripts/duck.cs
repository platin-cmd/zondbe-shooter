using System.Runtime.ExceptionServices;
using JetBrains.Annotations;
using StarterAssets;
using UnityEngine;

public class duck : MonoBehaviour
{

    public CapsuleCollider playerCollider;

    public CharacterController playerCharacterController;
    public FirstPersonController fpc;

    public KeyCode crouchKey = KeyCode.LeftControl;

    public Transform cameraTransform;
    public Transform crouchTransformCamera;
    private Vector3 initialCameraPosition;
    public bool isDuck = false;
    float initialMoveSpeed;
    float initialSprintSpeed;
    public float crouchSpeed = 6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialCameraPosition = cameraTransform.localPosition;

        initialMoveSpeed = fpc.MoveSpeed;
        initialSprintSpeed = fpc.SprintSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(crouchKey))
        {
            playerCollider.height = 1;
            playerCharacterController.height = 1;
            cameraTransform.localPosition = crouchTransformCamera.localPosition;
            isDuck = true;
            fpc.MoveSpeed = crouchSpeed;
            fpc.SprintSpeed = crouchSpeed;

        }
        else if (isDuck)
        {
            playerCollider.height = 2;
            playerCharacterController.height = 2;
            cameraTransform.localPosition = initialCameraPosition;
            isDuck = false;
            fpc.MoveSpeed = initialMoveSpeed;
            fpc.SprintSpeed = initialSprintSpeed; 
        }
    }
}
