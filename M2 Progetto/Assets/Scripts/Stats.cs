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
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = 10;
        this.eva = eva;
    }
    public static int Sum(Stats a , Stats b )
    {
        int risultato;
        risultato = a.atk + b.atk;
        risultato = a.def + b.def;
        risultato = a.res + b.res;
        risultato = a.spd + b.spd;
        risultato = a.crt + b.crt;
        risultato = a.aim + b.aim;
        risultato = a.eva + b.eva;

        return risultato ;
    }

    public enum ELEMENT { NONE , FIRE , ICE , LIGHTNING}
}




