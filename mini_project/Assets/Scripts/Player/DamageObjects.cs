using UnityEngine;

public class DamageObjects : MonoBehaviour
{
    public float damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        // Wenn das Objekt mit dem kollidiert wurde ein Compontent besitzt, dass das Interface IDamageable implementiert, so wird dieses Compontent zurückgegeben
        // und die "ApplyDamage()" Methode wird ausgeführt, wodurch das Objekt schaden bekomment.
        IDamageable damageableObject = (IDamageable)collision.gameObject.GetComponent(typeof(IDamageable));
        if (damageableObject != null)
        {
            damageableObject.ApplyDamage(damageAmount);
        }
    }
}
