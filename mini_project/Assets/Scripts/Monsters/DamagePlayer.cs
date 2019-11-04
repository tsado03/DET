using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount;
    public float timeBetweenAttacks;


    private float lastTimeAttacked;
    
    
    // Start is called before the first frame update
    void Start()
    {
        lastTimeAttacked = Time.time;
    }


    private void OnCollisionStay(Collision collision)
    {
        // Soll nur dem Spieler Schaden zufügen und nicht anderen Monstern
        if( collision.gameObject.tag == "Player")
        {
            // Kann nur nach gewisser Zeit wieder angreifen und nicht jeden Frame
            if (Time.time - lastTimeAttacked >= timeBetweenAttacks)
            {
                // Wenn das Objekt mit dem kollidiert wurde ein Compontent besitzt, dass das Interface IDamageable implementiert, so wird dieses Compontent zurückgegeben
                // und die "ApplyDamage()" Methode wird ausgeführt, wodurch das Objekt schaden bekomment.
                IDamageable damageableObject = (IDamageable)collision.gameObject.GetComponent(typeof(IDamageable));
                if (damageableObject != null)
                {
                    damageableObject.ApplyDamage(damageAmount);
                    lastTimeAttacked = Time.time;
                }
            }
        }
        
    }
}
