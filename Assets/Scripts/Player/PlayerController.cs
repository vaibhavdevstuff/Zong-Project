using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float Speed = 5f;
    public float Gravity = 9.18f;

    [Header("Look")]
    public float MouseSensitivity = 2f;
    public float TopClamp = 70;
    public float BottomClamp = 70f;

    [Header("Look")]
    public LayerMask interabtableLayer;

    private float cameraRotationX = 0f;
    private float ySpeed = 0f;

    private float moveX, moveY;
    private float lookX, lookY;

    private GameObject interactableObject;

    private Transform cam;
    private CharacterController characterController;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>().transform;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            CheckpointManager.Instance.GotoPreviousCheckpoint(gameObject);
        }

        UpdateInput();
        Movement();
        MouseLook();
        Interact();
    }

    private void UpdateInput()
    {
        //Move Input
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        //Mouse Input
        lookX = Input.GetAxis("Mouse X") * MouseSensitivity;
        lookY = -Input.GetAxis("Mouse Y") * MouseSensitivity;
    }

    private void Movement()
    {
        if (!characterController.isGrounded)
        {
            ySpeed -= Gravity * Time.deltaTime;
        }
        else
        {
            ySpeed = -Gravity * Time.deltaTime; // Prevents accumulating gravity when grounded
        }
        
        Vector3 moveDirection = new Vector3(moveX, ySpeed, moveY).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 moveVector = transform.TransformDirection(moveDirection) * Speed * Time.deltaTime;
            characterController.Move(moveVector);
        }
    }

    private void MouseLook()
    {
        transform.Rotate(Vector3.up * lookX);

        cameraRotationX += lookY;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -TopClamp, BottomClamp);
        cam.localRotation = Quaternion.Euler(cameraRotationX, 0f, 0f);
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F) && interactableObject)
        {
            var item = interactableObject.GetComponent<BaseInteractable>();

            if (item)
            {
                item.Interact(gameObject);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (interabtableLayer == (interabtableLayer | (1 << other.gameObject.layer)))
        {
            interactableObject = other.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (interabtableLayer == (interabtableLayer | (1 << other.gameObject.layer)) && interactableObject == other.gameObject)
        {
            interactableObject = null;

        }
    }
























}
