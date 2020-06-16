using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker2D : MonoBehaviour
{
    public bool isGrounded;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isGrounded = false;
        }
    }
}
