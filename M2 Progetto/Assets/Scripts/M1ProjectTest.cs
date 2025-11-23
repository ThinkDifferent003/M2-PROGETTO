using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{

    [SerializeField] private Hero a;
    [SerializeField] private Hero b;
    private int state = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MicioAttack()
    {
        Debug.Log($"L'Eroe {a.GetName()} sta attaccando l'Eroe {b.GetName()}");
        if (!GameFormulas.HasHit(a.GetBaseStats(), b.GetBaseStats()))
        {
            Debug.Log($"L'Eroe {b.GetName()} ha schivato il colpo");
            state = 2;
            return;
        }
        int damage = GameFormulas.CalculateDamage(a , b);
        Debug.Log($"L'Eroe {a.GetName()} ha sferrato {damage} danni");
        b.TakeDamage(damage);
        Debug.Log($"L'Eroe {b.GetName()} ha ricevuto {damage} danni!");
        Debug.Log($"HP rimanenti di {b.GetName()} : {b.GetHp()}");
        if (b.IsAlive())
        {
            Debug.Log($"L'Eroe {b.GetName()} ha resistito");
            state = 2;
        }
        else if (!b.IsAlive())
        {
            Debug.Log($"L'Eroe {a.GetName()} ha VINTO!");
            state = 3;
        }
    }

    public void CaneAttack()
    {
        Debug.Log($"L'eroe {b.GetName()} sta attaccando l'Eroe {a.GetName()}");
        if (!GameFormulas.HasHit(b.GetBaseStats(), a.GetBaseStats()))
        {
            Debug.Log($"L'Eroe {a.GetName()} ha schivato il colpo");
            state = 1;
            return;
        }
        int damage = GameFormulas.CalculateDamage(b , a);
        Debug.Log($"L'Eroe {b.GetName()} ha sferrato {damage} danni");
        a.TakeDamage(damage);
        Debug.Log($"L'Eroe {a.GetName()} ha ricevuto {damage} danni!");
        Debug.Log($"HP rimanenti di {a.GetName()} : {a.GetHp()}");
        if (a.IsAlive())
        {
            Debug.Log($"L'eroe {a.GetName()} ha resistito");
            state = 1;
        }
        else if (!a.IsAlive())
        {
            Debug.Log($"L'Eroe {b.GetName()} ha VINTO!");
            state = 3;
        }
    }

    

    public void WhoStart()
    {
       if (a.GetBaseStats().spd + a.GetWeapon().GetStats().spd > b.GetBaseStats().spd + b.GetWeapon().GetStats().spd)
        {
            Debug.Log($"L'Eroe {a.GetName()} attacherà per primo l'Eroe {b.GetName()}");



        }
        else
        {
            Debug.Log($"L'Eroe {b.GetName()} attacherà per primo l'Eroe {a.GetName()}");

        }
    }

    public void Switch()
    {
        switch (state)
        {
            case 0:
                WhoStart();
                if (a.GetBaseStats().spd +a.GetWeapon().GetStats().spd >= b.GetBaseStats().spd + b.GetWeapon().GetStats().spd)
                {
                    state = 1;
                }
                else
                {
                    state = 2;
                }
                break;
            case 1:
                MicioAttack();
                break;
            case 2:
                CaneAttack();
                break;
            case 3:
                Debug.Log("Fine");
                break;
        }

    }




    // Update is called once per frame
    void Update()
    {
        Switch();
    }
}
