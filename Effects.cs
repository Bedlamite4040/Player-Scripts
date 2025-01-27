using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Jobs;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]
public class Effects : MonoBehaviour
{
    public float Gravity = 9.8f;
    private Vector3 displacement;
    private CharacterController CharacterController;
     

    // Start is called before the first frame update
    void Start()
    {
         CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CharacterController.isGrounded)
        {
            displacement.y -= Gravity * Time.deltaTime;
        }
       
        CharacterController.Move(displacement * Time.deltaTime);
    }
}