using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {
    [SerializeField]
    private int startHealth;
    private int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = startHealth;
	}

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        CheckDead();
    }

    protected void CheckDead()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
        Debug.Log(currentHealth);
    }
}
