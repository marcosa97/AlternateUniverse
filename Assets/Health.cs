using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {
    [SerializeField]
    protected int startHealth;
    protected int currentHealth;

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        CheckDead();
    }

    protected void CheckDead()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
