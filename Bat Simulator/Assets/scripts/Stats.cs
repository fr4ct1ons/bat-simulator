using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [SerializeField] private float health, maxHealth = 100;
    [SerializeField] private bool resetHealthOnAwake = true;

    public UnityEvent OnHealthZero;
    public UnityEvent OnReceiveDamage;

    public delegate void StatsDelegate(float damage);

    public event StatsDelegate OnReceiveDamageVal;

    private void Awake()
    {
        if (resetHealthOnAwake)
            health = maxHealth;
    }

    public void SendDamage(float damage)
    {
        health -= damage;
        OnReceiveDamage.Invoke();
        OnReceiveDamageVal?.Invoke(damage);
        if (health <= 0.0f)
        {
            OnHealthZero.Invoke();
        }
    }
}
