using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class FreeRoam : MonoBehaviour
{
    private CharacterController characterController;
    public GameObject Player;
    public GameObject PlayerCamera;
    public Vector3 MovementDirection;
    public float WalkingSpeed = 10f;
    public float rotationX = 0;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeedX = WalkingSpeed * Input.GetAxis("Vertical");
        float curSpeedY = WalkingSpeed * Input.GetAxis("Horizontal");
        MovementDirection = (forward * curSpeedX) + (right * curSpeedY);

        characterController.Move(MovementDirection * Time.deltaTime);

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        PlayerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

    }
}
