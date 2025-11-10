using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon 
{
    public enum DAMAGE_TYPE { PHYSICAL , MAGICAL}
    [SerializeField] private string name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private Stats.ELEMENT elem;
    [SerializeField] private Stats bonusStats;

    public Weapon ( string name , DAMAGE_TYPE dmgType , Stats.ELEMENT elem , Stats bonusStats)
    {
        this.name = name;
        this.dmgType = dmgType;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }
    public string GetName()
    {
        return name;
    }
    public void SetName( string nameNew)
    {
        
        if(string.IsNullOrWhiteSpace(nameNew))
        {
            name = nameNew;
        }
    }
    public DAMAGE_TYPE GetDmgType()
    {
        return dmgType;
    }

    public void SetDmgType(DAMAGE_TYPE damage)
    {
        dmgType = damage;
    }

    public Stats.ELEMENT GetElement()
    {
        return elem;
    }

    public void SetElement(Stats.ELEMENT elem)
    {
        this.elem = elem;
    }
    public Stats GetStats()
    {
        return bonusStats; 
    }

    public void SetStats(Stats bonusStats)
    {
        this.bonusStats = bonusStats;
    }
  
}
