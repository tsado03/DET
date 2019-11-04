using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable, IHealable
{
    public float maxHealth;

    private float currentHealth;
    private int numOfHeartContainers;
    private Health_GUI hg;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hg = gameObject.GetComponent<Health_GUI>();
    }


    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHealthGUI()
    {
        hg.SetHealth(currentHealth, maxHealth);
    }

    public void ApplyDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        UpdateHealthGUI();
        Debug.Log("Player Damaged! CurrentHealth: " + currentHealth);
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthGUI();
        Debug.Log("Player Healed! CurrentHealth: " + currentHealth);
    }
}
