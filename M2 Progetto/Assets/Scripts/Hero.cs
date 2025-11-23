using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

[System.Serializable]
public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon weapon;

    public Hero(string name , int hp , Stats baseStats , ELEMENT resistance , ELEMENT weakness , Weapon weapon)
    {
        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapon = weapon;

    }

    public void AddHp(int amount)
    {
        SetHp(hp + amount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
        if (hp < 0)
        {
            hp = 0;
        }
    }

    public bool IsAlive()
    {
        if (hp <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        
         
        
    }

    public string GetName() => name;
   
    public void SetName(string nameNew)
    {

        if (string.IsNullOrWhiteSpace(nameNew))
        {
            name = nameNew;
        }
    }

    public int GetHp() => hp;
    

    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    public Stats GetBaseStats() => baseStats;
   
    

    public void SetBaseStats(Stats baseStats)
    {
        this.baseStats = baseStats;
    }

    public ELEMENT GetResitance() => resistance;
    

    public void SetResistance(ELEMENT resistance)
    {
        this.resistance = resistance;
    }

    public ELEMENT GetWeakness() => weakness;
    

    public void SetWeakness(ELEMENT weakness)
    {
        this.weakness = weakness;
    }

    public Weapon GetWeapon() => weapon;
    
    public void SetWeapon(Weapon weapon)
    {
        this.weapon=weapon;
    }
        

        
        
}
