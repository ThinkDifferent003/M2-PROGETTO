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

    public static int CalculateDamage(Hero attacker , Hero defender)
    {
        Weapon attackerWeapon = attacker.GetWeapon();
        Stats attackerStats = Stats.Sum(attacker.GetBaseStats() , attackerWeapon.GetStats());

        Weapon defenderWeapon = defender.GetWeapon();
        Stats defenderStats = Stats.Sum(defender.GetBaseStats() , defenderWeapon.GetStats());

        int defense = 0;
        //switch(attackerWeapon.GetDmgType())
        //{
        //    case Weapon.DAMAGE_TYPE.PHYSICAL:
        //         defense = defenderStats.def;
        //        break;

        //    case Weapon.DAMAGE_TYPE.MAGICAL:
        //        defense = defenderStats.res;
        //        break;

        //}

        if (attackerWeapon.GetDmgType() == Weapon.DAMAGE_TYPE.PHYSICAL)
        {
            defense = defenderStats.def;
        }
        else if (attackerWeapon.GetDmgType() == Weapon.DAMAGE_TYPE.MAGICAL)
        {
            defense = defenderStats.res;
        }
        

            int damageBase = attackerStats.atk - defense;
        EvaluateElementalModifier(Stats.ELEMENT.NONE, defender);
        EvaluateElementalModifier(Stats.ELEMENT.FIRE, defender);
        EvaluateElementalModifier(Stats.ELEMENT.ICE, defender);
        EvaluateElementalModifier(Stats.ELEMENT.LIGHTNING, defender);

        if (IsCrit(damageBase))
        {
            damageBase *= 2;
        }

        //if (damageBase < 0)
        //{
        //    damageBase = 0;
        //}
        
        return damageBase;
    }
}
