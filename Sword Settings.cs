using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class SwordSettings : MonoBehaviour
{
    public GameObject MeeleWeapon;
    public GameObject Player;
    private bool MeeleOut;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.E))
        {
            if (MeeleOut)
            {
                MeeleWeapon.SetActive(false);
                MeeleOut = false;
            }
            else
            {
                MeeleWeapon.SetActive(true);
                MeeleOut = true;                
            }
        }
    }
}
