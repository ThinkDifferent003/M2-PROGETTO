using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct Stats
{
    public int atk, def, res, spd, crt, aim, eva;

    public Stats(int atk, int def, int res , int spd , int crt , int aim ,int eva)
    {
        this.atk = 10;
        this.def = 10;
        this.res = 10;
        this.spd = 10;
        this.crt = 10;
        this.aim = 10;
        this.eva = 10;
    }
    public static Stats Sum (Stats a , Stats b )
    {
        return new Stats (a.atk + b.atk , a.def + b.def , a.res + b.res , + a.spd + b.spd , a.crt + b.crt , a.aim + b.aim , a.eva + b.eva);
        
    }

    public enum ELEMENT { NONE , FIRE , ICE , LIGHTNING}
}




