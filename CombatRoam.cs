using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class CombatRoam : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject Player;
    public float HighX;
    public float HighY;
    public float LowX;
    public float LowY;
    
    private float XPre;
    private float YPre;
    public LayerMask layerMask;
    void Start()
    {

    }

    void ShootRay() // The fuction shoots a ray that if hits an object will tell the coordinates of where it hit.
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition); //creates the ray

        RaycastHit Hit;
        
        if (Physics.Raycast(ray, out Hit, Mathf.Infinity)) //Asks if the ray has hit anything
        {
             Debug.Log(Hit.point);
    
        }
        else
        {
            Debug.Log("I DIDNT hit somethig ;(");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Input.mousePosition; //Grabs where the mouse is currently

        XPre = MousePos.x / Screen.width; //formula for finding where the mouse is when comparing to the sreen.
        YPre = MousePos.y / Screen.height; // Same as ^ (The top)

        Vector3 cameraPosition = MainCamera.transform.position; //Grabs the position of the camera

        switch(YPre) //Locates where the mouse is on the Y axis
        {
            case < 0.15f and >= 0.05f:
                cameraPosition.z -= LowY;
                break;
            case > 0.85f and <= 0.95f:
                cameraPosition.z += LowY;
                break;
            case < 0.05f:
                cameraPosition.z -= HighY;
                break;
            case > 0.95f:
                cameraPosition.z += HighY;
                break;
        }

        switch(XPre) //Locates where the mouse is on the X axis
        {
            case < 0.15f and >= 0.05f:
                cameraPosition.x -= LowX;
                break;
            case > 0.85f and <= 0.95f:
                cameraPosition.x += LowX;
                break;
            case < 0.05f:
                cameraPosition.x -= HighX;
                break;
            case > 0.95f:
                cameraPosition.x += HighX;
                break;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            ShootRay(); //Line 25
        }

        MainCamera.transform.position = cameraPosition;
    }
}
