using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // Default value
    public int currentHealth;
    public bool alive;
    public Slider healthBar;
    public GameObject healthBarGameObject;

    void Start()
    {
        alive = true;
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBarGameObject.SetActive(false);
    }

    public void regen()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
            alive = false;
            UpdateHealthBar();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsAlive()
    {
        return alive;
    }

    public bool IsAtFullHealth()
    {
        return currentHealth == maxHealth;
    }

    public void UpdateHealthBar()
    {
        if (!IsAtFullHealth())
        {
            // Enable;
            healthBarGameObject.SetActive(true);
            healthBar.value = GetCurrentHealth();
        }
    }
}
