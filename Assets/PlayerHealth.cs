using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class PlayerHealth : Health {
    private Slider slider;

    private void Start()
    {
        slider = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        currentHealth = startHealth;
        slider.value = currentHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(25);
            CheckDead();
            UpdateSlider();
        }
    }

    private void UpdateSlider()
    {
        slider.value = currentHealth;
    }
}
