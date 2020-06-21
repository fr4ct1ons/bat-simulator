using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private Rigidbody2D rb;
    private Transform playerBat;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerBat = FindObjectOfType<BatBehaviour>().transform;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, playerBat.position, speed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Stats>(out Stats stats))
        {
            stats.SendDamage(damage);
        }
    }
}
