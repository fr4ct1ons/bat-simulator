using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FrogBehaviour : MonoBehaviour
{
    [SerializeField] private float minJumpForce = 100.0f, maxJumpForce = 100.0f;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        
    }
}
