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
    public int GetTotalSpeed(Hero spd)
    {
        return spd.GetBaseStats().spd + spd.GetWeapon().GetStats().spd;
    }
    public void Attack(Hero attacker , Hero defender ,int nextState)
    {
        Debug.Log($"L'Eroe {attacker.GetName()} sta attaccando l'Eroe {defender.GetName()}");
        if (!GameFormulas.HasHit(attacker.GetBaseStats(), defender.GetBaseStats()))
        {
            Debug.Log($"L'Eroe {defender.GetName()} ha schivato il colpo");
            state = nextState;
            return;
        }
        int damage = GameFormulas.CalculateDamage(attacker, defender);
        Debug.Log($"L'Eroe {attacker.GetName()} ha sferrato {damage} danni");
        b.TakeDamage(damage);
        Debug.Log($"L'Eroe {defender.GetName()} ha ricevuto {damage} danni!");
        Debug.Log($"HP rimanenti di {defender.GetName()} : {defender.GetHp()}");
        if (defender.IsAlive())
        {
            Debug.Log($"L'Eroe {defender.GetName()} ha resistito");
            state = nextState;
        }
        else  
        {
            Debug.Log($"L'Eroe {attacker.GetName()} ha VINTO!");
            state = 3;
        }
    }

    public void MicioAttack()
    {
        Attack(a,b,2);
    }

    public void CaneAttack()
    {
        Attack(b,a,1);
    }

    

    public void WhoStart()
    {
       if (GetTotalSpeed(a) >= GetTotalSpeed(b))
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
                if (GetTotalSpeed(a) >= GetTotalSpeed(b))
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
        //So che c'è un qualche tipo di errore, nella console vedo che mi escono messaggi ed arriva alla fine del combattimento
        //ma non come me lo immagino e come penso dovrebbe essere.
        //Purtroppo non sono riuscito veramente a capire quali errori possa aver commesso, quando mi corregerete il lavoro vorrei proprio
        //sapere quale fosse il mio errore... Comunque Grazie!
        Switch();
    }
}
