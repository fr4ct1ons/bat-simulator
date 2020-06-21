using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private new SpriteRenderer renderer;
    
    
    private Rigidbody2D rb;
    private Transform playerBat;

    private void Awake()
    {
        if(!rb)
            rb = GetComponent<Rigidbody2D>();
        if (!renderer)
            renderer = GetComponent<SpriteRenderer>();
        
        playerBat = FindObjectOfType<BatBehaviour>().transform;
    }

    private void Update()
    {
        if (playerBat.position.x > transform.position.x)
        {
            renderer.flipX = false;
        }
        else
        {
            renderer.flipX = true;
        }
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
            GetComponent<Animator>().SetTrigger("Death");
            rb.simulated = false;
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
