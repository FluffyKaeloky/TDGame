using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public float CurrentHealth { 
        get 
        {
            return currentHealth;
        } 
        set 
        {
            float previous = currentHealth;
            currentHealth = Mathf.Clamp(value, 0.0f, maxHealth);

            if (currentHealth != previous)
                onHealthChanged?.Invoke();

            if (currentHealth == 0.0f && previous > 0.0f)
                onDeath?.Invoke();
        }
    }

    public bool IsAlive { get { return CurrentHealth > 0.0f; } }

    private float currentHealth = 0.0f;
    public float maxHealth = 100.0f;

    public UnityEvent onHealthChanged = new UnityEvent();
    public UnityEvent onDeath = new UnityEvent();

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }
}
