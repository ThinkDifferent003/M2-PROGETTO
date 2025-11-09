using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon 
{
    public enum DAMAGE_TYPE { PHYSICAL , MAGICAL}
    private string name;
    private DAMAGE_TYPE dmgType;
    private Stats.ELEMENT elem;
    private Stats bonusStats;

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
    public void SetName( string nome)
    {
        
        if(string.IsNullOrWhiteSpace(nome))
        {
            name = nome;
        }
    }
    public DAMAGE_TYPE GetDmgType()
    {
        return dmgType;
    }

    public Stats.ELEMENT GetElement()
    {
        return elem;
    }

    public Stats GetStats()
    {
        return bonusStats; 
    }
  
}
