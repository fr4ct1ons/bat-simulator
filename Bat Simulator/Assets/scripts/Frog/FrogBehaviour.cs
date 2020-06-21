using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class FrogBehaviour : MonoBehaviour
{
    [SerializeField] private float minJumpForce = 100.0f, maxJumpForce = 100.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float timeBetweenJumps;
    [SerializeField] private GroundChecker2D groundChecker;
    [SerializeField] private Animator anim;
    [SerializeField] private float damage;

    private float currentJumpTime;

    private void Awake()
    {
        if (!anim)
            anim = GetComponent<Animator>();
        if (!rb)
            rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (groundChecker.isGrounded)
        {
            currentJumpTime += Time.deltaTime;
            if (currentJumpTime >= timeBetweenJumps)
            {
                rb.AddForce(new Vector2(0.0f, Random.Range(minJumpForce, maxJumpForce)));
                currentJumpTime = 0.0f;
                anim.SetTrigger("Jump");
                anim.SetBool("IsGrounded", false);
                Debug.Log("Jump");
            }
        }
    }

    public void IdleAnimation()
    {
        anim.SetBool("IsGrounded", true);
    }
    
    public void JumpAnimation()
    {
        anim.SetTrigger("Jump");
    }

    public void DeathAnimation()
    {
        anim.SetTrigger("Death");
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void HitAnimation()
    {
        anim.SetTrigger("Hit");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Stats>(out Stats otherStats))
        {
            otherStats.SendDamage(damage);
        }
    }
}
