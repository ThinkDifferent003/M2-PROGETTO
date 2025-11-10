using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private Stats.ELEMENT resistance;
    [SerializeField] private Stats.ELEMENT weakness;
    [SerializeField] private Weapon weapon;

    public Hero(string name , int hp , Stats baseStats , Stats.ELEMENT resistance , Stats.ELEMENT weakness , Weapon weapon)
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
        AddHp( - damage);
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

    public string GetName()
    {
        return name;
    }
    public void SetName(string nameNew)
    {

        if (string.IsNullOrWhiteSpace(nameNew))
        {
            name = nameNew;
        }
    }

    public int GetHp()
    {
        return hp;
    }

    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    public Stats GetBaseStats()
    {
        return baseStats;
    }

    public void SetBaseStats(Stats baseStats)
    {
        this.baseStats = baseStats;
    }

    public Stats.ELEMENT GetResitance()
    {
        return resistance;
    }

    public void SetResistance(Stats.ELEMENT resistance)
    {
        this.resistance = resistance;
    }

    public Stats.ELEMENT GetWeakness()
    {
        return weakness;
    }

    public void SetWeakness(Stats.ELEMENT weakness)
    {
        this.weakness = weakness;
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon=weapon;
    }
        

        
        
}
