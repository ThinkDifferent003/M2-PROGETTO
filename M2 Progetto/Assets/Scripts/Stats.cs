using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ELEMENT { NONE , FIRE , ICE , LIGHTNING}

[System.Serializable]

public struct Stats
{
    public int atk, def, res, spd, crt, aim, eva;

    public Stats(int atk, int def, int res , int spd , int crt , int aim ,int eva)
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }
    public static Stats Sum (Stats a , Stats b )
    {
        return new Stats (a.atk + b.atk , a.def + b.def , a.res + b.res , + a.spd + b.spd , a.crt + b.crt , a.aim + b.aim , a.eva + b.eva);
        
    }

    
}





