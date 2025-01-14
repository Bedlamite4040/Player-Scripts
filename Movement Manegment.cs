using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class MovementManegment : MonoBehaviour
{
    public FreeRoam FreeRoamScript;
    public CombatRoam CombatRoamScript;
    public bool InCombat;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject PlayerCharacter;
    public Quaternion StoringPose;

    static void FreeRoam(GameObject Player, GameObject PlayerCamera, CombatRoam CombatRoamScript ,FreeRoam FreeRoamScript)
    {
        FreeRoamScript.enabled = true;
        CombatRoamScript.enabled = false;
    
        PlayerCamera.transform.localPosition = new Vector3(0.22f,1.28f,-3.03f);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    static void CombatRoam(GameObject Player, GameObject PlayerCamera, CombatRoam CombatRoamScript ,FreeRoam FreeRoamScript)
    {
        FreeRoamScript.enabled = false;
        CombatRoamScript.enabled = true;
        
        Player.transform.rotation = Quaternion.Euler(0,0,0);
        PlayerCamera.transform.localPosition = new Vector3(0f,5f,-4f);
        PlayerCamera.transform.rotation = Quaternion.Euler(50f,0f,0f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
 
    // Start is called before the first frame update
    void Start()
    {
        FreeRoamScript = GetComponent<FreeRoam>();
        CombatRoamScript = GetComponent<CombatRoam>();
        FreeRoamScript.enabled = false;
        CombatRoamScript.enabled = false;
        InCombat = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(!InCombat)
            {
                CombatRoam(Player, PlayerCamera, CombatRoamScript , FreeRoamScript);
                InCombat = true;
            }
            else
            {
                FreeRoam(Player, PlayerCamera, CombatRoamScript , FreeRoamScript);
                InCombat = false;
            }
        }
    }
}