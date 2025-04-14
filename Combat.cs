using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{

    public Character Hero = new Character();
    public Character Goblin = new Character();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hero._health > 0 && Goblin._health > 0){
            CombatLoop(Hero, Goblin);
        }
        else if(Hero._health <= 0){
            Debug.Log("Hero Lost");
        }
        else if(Goblin._health <= 0){
            Debug.Log("Hero Won");
        }
        else{
            Debug.Log("Error");
        }
    }

    void CombatLoop(Character Player, Character Enemy)
    {
        int iniative_count = 100;
        int damage = 0;
        for(int i = iniative_count; i > 0; i--){
            if(i == Player._speed && Player._health > 0){
                //Buttons go here later
                damage = DamageCalc(Enemy, "slash", Player);
                Enemy._health -= damage;
                damage = 0;
                Debug.Log("Enemy: " + Enemy._health);
            }
            
            if(i == Enemy._speed && Enemy._health > 0){
                //Buttons go here later
                damage = DamageCalc(Player, "slash", Enemy);
                Player._health -= damage;
                Debug.Log("Player: " + Player._health);
                damage = 0;
            }
        }
    }

    static int DamageCalc(Character Defender, string attack, Character Attacker)
    {
        int damage = 0;
        
        if(attack == "slash"){
            damage = AttackDictionary.Slash(Attacker);
            damage = damage - (Defender._physical / 10);
        }
        return damage;
    }

    
}

public class Character
{
    public int _health = 100;
    public int _mana = 100;
    public int _speed = 100;
    public int _physical = 10;
    public int _magic = 10;
    public int _accuracy =10;
    public int _technical = 10;
}