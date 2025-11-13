using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{

    [SerializeField] private Hero a;
    [SerializeField] private Hero b;
    //[SerializeField] private Weapon c;

    

    // Start is called before the first frame update
    void Start()
    {
        a.SetName("Micio");
        
    }

    
    
        

    // Update is called once per frame
    void Update()
    {
        
        
        //if(a.IsAlive() || b.IsAlive())
        //{
        //    return;
        //}
        
        
        if(a.GetBaseStats().spd + a.GetWeapon().GetStats().spd > b.GetBaseStats().spd + b.GetWeapon().GetStats().spd)
        {
            Debug.Log($"L'Eroe {a.GetName()} sta attaccando l'Eroe {b.GetName()}");
            


        }
        else
        {
            Debug.Log($"L'Eroe {b} sta attaccando l'Eroe {a}");
            
        }
        

        



        GameFormulas.HasHit(a.GetBaseStats(), b.GetBaseStats());
        if ( a.GetWeapon().GetElement() == b.GetWeakness())
        {
            Debug.Log("WEAKNESS");
        }
        else if (a.GetWeapon().GetElement() == b.GetResitance())
        {
            Debug.Log("RESIST");
        }
        int damage;
        damage = GameFormulas.CalculateDamage(a, b);
        Debug.Log(damage);
        
    }
}
