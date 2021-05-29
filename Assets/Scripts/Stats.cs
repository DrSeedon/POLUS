using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

    public Text healthDisplay;
    public Text ammoDisplay;

    public bool existUI = false;

    public float health = 100f;
    public int ammo = 100;

    public void TakeDamage(float amount)
    {
        health -= amount;
        UpdateStats();
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void UpdateStats()
    {
        if (!existUI) return;
        healthDisplay.text = "Health: " + health.ToString();
        if (health <= 0f)
        {
            healthDisplay.text = "Health: DIE";
        }
        ammoDisplay.text = "Ammo: " + ammo.ToString();
    }
}
