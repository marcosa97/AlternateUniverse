using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(25);
            CheckDead();
        }
    }
}
