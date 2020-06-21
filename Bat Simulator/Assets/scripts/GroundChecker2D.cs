using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker2D : MonoBehaviour
{
    public bool isGrounded;

    public UnityEvent onBecomeGrounded, onBecomeUngrouded;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
        onBecomeGrounded.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
        onBecomeUngrouded.Invoke();
    }
}
