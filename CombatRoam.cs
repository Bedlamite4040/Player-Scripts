using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CombatRoam : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject Player;
    public float CameraSpeed;
    void Start()
    {

    }

    Vector3 ShootRay() // The fuction shoots a ray that if hits an object will tell the coordinates of where it hit.
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition); //creates the ray

        RaycastHit Hit;
        
        if (Physics.Raycast(ray, out Hit, Mathf.Infinity)) //Asks if the ray has hit anything
        {
            Debug.Log(Hit.point);   
        }
        return Hit.point;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetKey(KeyCode.D) ? CameraSpeed : (Input.GetKey(KeyCode.A) ? -CameraSpeed : 0), 0, Input.GetKey(KeyCode.W) ? CameraSpeed : (Input.GetKey(KeyCode.S) ? -CameraSpeed : 0)); 
        MainCamera.transform.position += inputDirection * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 targetPosition = ShootRay(); // Line 25
            Vector3 direction = targetPosition - Player.transform.position;

            // Use Mathf.Atan2 to calculate the angle in degrees
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Rotate the player to face the target direction
            Player.transform.rotation = Quaternion.Euler(0, angle, 0);
        }

    }
}