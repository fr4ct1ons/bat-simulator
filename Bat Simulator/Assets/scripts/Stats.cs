using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [SerializeField] private float health, maxHealth = 100;
    [SerializeField] private bool resetHealthOnAwake = true;
    [SerializeField] private bool invulnerable = false;

    public bool Invulnerable
    {
        get => invulnerable;
        set => invulnerable = value;
    }

    public float Health
    {
        get => health;
        set => health = value;
    }

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
    
    public UnityEvent OnHealthZero;
    public UnityEvent OnReceiveDamage;
    public UnityEvent OnReceiveDamageVulnerable;

    public delegate void StatsDelegate(float damage);

    public event StatsDelegate OnReceiveDamageVal;

    private void Awake()
    {
        if (resetHealthOnAwake)
            health = maxHealth;
    }

    public void SendDamage(float damage)
    {
        if (!invulnerable)
        {
            health -= damage;
            Debug.Log(gameObject + " received damage!");
            OnReceiveDamage.Invoke();
            OnReceiveDamageVal?.Invoke(damage);
            if (health <= 0.0f)
            {
                OnHealthZero.Invoke();
            }
        }
        else
        {
            OnReceiveDamageVulnerable.Invoke();
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
