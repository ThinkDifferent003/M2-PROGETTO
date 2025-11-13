using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{

    [SerializeField] private Hero a;
    [SerializeField] private Hero b;
   

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MicioAttack()
    {
        Debug.Log($"L'Eroe {a.GetName()} sta attaccando L'Eroe {b.GetName()}");
        if (GameFormulas.HasHit(a.GetBaseStats(), b.GetBaseStats()))
        {
            Debug.Log($"L'attacco va a segno");

            if (a.GetWeapon().GetElement() == b.GetWeakness())
            {
                Debug.Log($"WEAKNESS L'attacco dell'Eroe {a.GetName()} è superefficace");
            }
            else if (a.GetWeapon().GetElement() == b.GetResitance())
            {
                Debug.Log($"RESIST L'attacco dell'Eroe {a.GetName()} è poco efficace");
            }

            int damage;
            damage = GameFormulas.CalculateDamage(a, b);
            Debug.Log($"L'eroe {a.GetName()} infligge a Eroe {b.GetName()} la bellezza di {damage} danni");

            b.TakeDamage(damage);
            Debug.Log($"L'eroe {b.GetName()} riceve {damage} danni da parte dell' Eroe {a.GetName()} e gli rimangono {b.GetHp()} HP");


            if (b.IsAlive())
            {
                Debug.Log($"L'eroe {a.GetName()} ha VINTO");
                
            }
            else if (!b.IsAlive())
            {
                Debug.Log($"L'eroe {b.GetName()} è sopravvisuto");
                CaneAttack();
            }
        }
        else
        {
            CaneAttack();
        }
    }

    public void CaneAttack()
    {
        Debug.Log($"L'Eroe {b.GetName()} sta attaccando L'Eroe {a.GetName()}");
        if (GameFormulas.HasHit(b.GetBaseStats(), a.GetBaseStats()))

        {
            if (b.GetWeapon().GetElement() == a.GetWeakness())
            {
                Debug.Log($"WEAKNESS L'attacco dell'Eroe {b.GetName()} è superefficace");
            }
            else if (b.GetWeapon().GetElement() == a.GetResitance())
            {
                Debug.Log($"RESIST L'attacco dell'Eroe {b.GetName()} è poco efficate");
            }
            int damage;
            damage = GameFormulas.CalculateDamage(b, a);
            Debug.Log($"L'eroe {b.GetName()} infligge a Eroe {a.GetName()} la bellezza di {damage} danni");

            b.TakeDamage(damage);
            Debug.Log($"L'eroe {a.GetName()} riceve {damage} danni da parte dell' Eroe {b.GetName()} e gli rimangono {a.GetHp()} HP");


            if (!a.IsAlive())
            {
                Debug.Log($"L'eroe {b.GetName()} ha VINTO");
                
            }
            else if (a.IsAlive())
            {
                Debug.Log($"L'Eroe {a.GetName()} è sopravvisuto");
                MicioAttack();
            }
        }
        else
        {
            MicioAttack();
        }
    }

    public void Attack()
    {
        
        MicioAttack();
        CaneAttack();
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




    // Update is called once per frame
    void Update()
    {

        WhoStart();
        Attack();


        

        




       


    }
}
