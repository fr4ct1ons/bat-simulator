using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Stats>(out Stats stats))
        {
            stats.SendDamage(damage);
        }
    }
    
    
}
