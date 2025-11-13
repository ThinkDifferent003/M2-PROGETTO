using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public static class GameFormulas 
{
    public static bool HasElementAdvantage(ELEMENT attackElement , Hero defender)
    {
        return attackElement == defender.GetWeakness();
    }

    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        return attackElement == defender.GetResitance();
    }

    public static float EvaluateElementalModifier( ELEMENT attackElement, Hero defender)
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
        

        if (attackerWeapon.GetDmgType() == Weapon.DAMAGE_TYPE.PHYSICAL)
        {
            defense = defenderStats.def;
        }
        else if (attackerWeapon.GetDmgType() == Weapon.DAMAGE_TYPE.MAGICAL)
        {
            defense = defenderStats.res;
        }


        int damageBase = attackerStats.atk - defense;
        float elementMod = EvaluateElementalModifier(attackerWeapon.GetElement(), defender);
        damageBase = Mathf.RoundToInt(damageBase * elementMod);

        if (IsCrit(damageBase))
        {
            damageBase *= 2;
        }

        if (damageBase < 0)
        {
            damageBase = 0;
        }

        return damageBase;
    }
}
