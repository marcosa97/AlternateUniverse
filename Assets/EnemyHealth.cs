using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {
    private void Start()
    {
        currentHealth = startHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(5);
            CheckDead();
            Destroy(collision.gameObject);
        }
    }

}
