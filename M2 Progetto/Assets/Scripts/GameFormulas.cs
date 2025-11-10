using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public static class GameFormulas 
{
    public static bool HasElementAdvantage(Stats.ELEMENT attackElement , Hero defender)
    {
        switch (attackElement)
        {
            case Stats.ELEMENT.FIRE:
                if (attackElement == Stats.ELEMENT.FIRE)
                    return true;
                break;
            case Stats.ELEMENT.ICE:
                if (attackElement == Stats.ELEMENT.ICE)
                    return true;
                break;
            case Stats.ELEMENT.LIGHTNING:
                if (attackElement == Stats.ELEMENT.LIGHTNING)
                    return true;
                break;
            case Stats.ELEMENT.NONE:
                if (attackElement == Stats.ELEMENT.NONE)
                    return true;
                break;
        }
         return false;   
    }

    public static bool HasElementDisadvantage(Stats.ELEMENT attackElement, Hero defender)
    {
        switch (attackElement)
        {
            case Stats.ELEMENT.FIRE:
                if (attackElement == Stats.ELEMENT.FIRE)
                    return true;
                break;
            case Stats.ELEMENT.ICE:
                if (attackElement == Stats.ELEMENT.ICE)
                    return true;
                break;
            case Stats.ELEMENT.LIGHTNING:
                if (attackElement == Stats.ELEMENT.LIGHTNING)
                    return true;
                break;
            case Stats.ELEMENT.NONE:
                if (attackElement == Stats.ELEMENT.NONE)
                    return true;
                break;
        }
        return false;
    }

    public static float EvaluateElementalModifier(Stats.ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender))
        {
            return 1.5f;
        }

        else if (HasElementDisadvantage(attackElement, defender))
        {
            return 0.5f;
        }
        else
            return 1f;
    }

    public static bool HasHit(Stats attacker , Stats defender)
    {
        int hitChance;
        int numberRandom;
        hitChance = attacker.aim - defender.eva;
        numberRandom = Random.Range(0, 100);
        if (numberRandom > hitChance)
        {
            Debug.Log($"MISS");
            return false;
        }
        else
            return true;
    }

    public static bool IsCrit (int critValue)
    {
        int numberRandom;
        numberRandom= Random.Range(0, 100);
        if (numberRandom < critValue)
        {
            Debug.Log($"CRIT");
            return true;
        }
        else 
            return false;
    }

    public static int CalculateDamage(Hero attacker , Hero defender , Weapon weapon)
    {
        //Hero hero1 = new Hero("Micio", 7,  new Stats() , Stats.ELEMENT.FIRE , Stats.ELEMENT.LIGHTNING , new Weapon());
        //Weapon weapon1 = new Weapon("Graffio", Weapon.DAMAGE_TYPE.PHYSICAL, Stats.ELEMENT.LIGHTNING, new Stats() );
        ////Stats.Sum(hero1.GetBaseStats(), weapon1.GetStats());


        ////Hero hero2 = new Hero("Cane" , 1, new Stats(), Stats.ELEMENT.NONE, Stats.ELEMENT.ICE);
        ////Weapon weapon2 = new Weapon("Morso", Weapon.DAMAGE_TYPE.PHYSICAL, Stats.ELEMENT.FIRE , new Stats());
        ////Stats.Sum(hero2.GetBaseStats(), weapon2.GetStats());
        //Stats weaponStats = hero1.GetWeapon();
        ////weapon1.GetDmgType();
        //Stats.Sum(attacker.GetBaseStats(), );
        int attackerStats = 0;
        //Stats attackerWeapon = attacker.SetWeapon(Weapon.GetStats());
        //Stats defenderStats = defender.GetBaseStats();

        //switch(attackerStats)
        //{
        //    case attackerStats.SetWeapon(Weapon.DAMAGE_TYPE.PHYSICAL):
        //        return defenderStats.def;
        //        break;
        //}
        if (attacker.GetWeapon() != null)
        {
            Stats.Sum(attacker.GetBaseStats(), weapon.GetStats());
            return attackerStats;
        }
        else if (defender.GetWeapon() != null)
        {
            Stats.Sum(defender.GetBaseStats(), weapon.GetStats());
            return attackerStats;
        }

        
       
    }
}
