using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonBehaviour : MonoBehaviour
{
    [SerializeField] private float topY, bottomY;
    [SerializeField] private float speed;
    [SerializeField] private Transform playerBat;
    [SerializeField] private float verticalDistance = 1.0f;
    [SerializeField] private Animator anim;

    private Vector2 topVec, bottomVec;
    private bool isAttacking;

    private void Awake()
    {
        topVec = new Vector2(transform.position.x, topY);
        bottomVec = new Vector2(transform.position.x, bottomY);
        if (!playerBat)
            playerBat = FindObjectOfType<BatBehaviour>().transform;
        if (!anim)
            anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mathf.Abs(playerBat.position.y - transform.position.y) <= verticalDistance)
        {
            if(!isAttacking)
                Attack();
        }
        else if (playerBat.position.y > transform.position.y && !isAttacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, topVec, speed * Time.deltaTime);
            anim.SetInteger("Speed", 1);
        }
        else if (playerBat.position.y < transform.position.y && !isAttacking)
        {
            transform.position = Vector2.MoveTowards(transform.position, bottomVec, speed * Time.deltaTime);
            anim.SetInteger("Speed", -1);
        }
    }

    private void Attack()
    {
        isAttacking = true;
        anim.SetTrigger("Attack");
    }

    private void StopAttack()
    {
        isAttacking = false;
    }
}
