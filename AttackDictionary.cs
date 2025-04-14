using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDictionary
{
    public static int Slash(Character Attacker){
        int atk_dmg = Random.Range(5, 11) + (Attacker._physical / 10);
        return atk_dmg;
    }

}