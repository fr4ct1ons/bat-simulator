using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(Rigidbody2D))]
public class BatBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashSpeed;
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private Animator anim;

    private BatControls inputs;
    private bool canMove = true;
    private float currentDashDuration = 0.0f;
    
    private void Awake()
    {
        if (!rb)
            rb = GetComponent<Rigidbody2D>();
        if (!renderer)
            renderer = GetComponent<SpriteRenderer>();
        if (!anim)
            anim = GetComponent<Animator>();
        
        inputs = new BatControls();
        
        EnhancedTouchSupport.Enable();

        inputs.BatMap.Finger1.performed += ctx =>
        {
            if(canMove)
                Move(NormalizedMousePos(ctx.ReadValue<Vector2>()));
        };
        
        inputs.BatMap.FlyLeft.performed += ctx =>
        {
            if(canMove)
                Move(Vector2.zero);
        };
        
        inputs.BatMap.FlyRight.performed += ctx =>
        {
            if(canMove)
                Move(Vector2.right);
        };

        inputs.BatMap.Dash.performed += ctx =>
        {
            if (canMove)
                Dash();
        };
    }

    private void Move(Vector2 touchPos)
    {
        Debug.Log(touchPos);
        
        if (touchPos.x <= 0.4f)
        {
            OnJump();
            rb.AddForce(new Vector2(-0.4f, 0.6f) * jumpForce);
            renderer.flipX = true;
            Debug.Log("lol");
            
        }
        else if (touchPos.x >= 1.0f - 0.4f)
        {
            OnJump();
            rb.AddForce(new Vector2(0.4f, 0.6f) * jumpForce);
            renderer.flipX = false;
            Debug.Log("KEK");
        }
    }

    private void Dash()
    {
        anim.SetBool("StopDash", false);
        currentDashDuration = 0.0f;
        anim.SetTrigger("Dash");
        StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {
        canMove = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        while (!canMove)
        {
            float direction = renderer.flipX ? -1.0f : 1.0f;
            transform.position += transform.right * (dashSpeed * Time.deltaTime * direction);
            currentDashDuration += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            if (currentDashDuration >= dashDuration)
            {
                canMove = true;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.AddForce(transform.right * direction * 200.0f);
                anim.SetBool("StopDash", true);
            }
        }
    }

    private void OnJump()
    {
        rb.velocity = Vector2.zero;
        anim.SetTrigger("Fly");
    }

    public void HitAnimation()
    {
        anim.SetTrigger("Hit");
    }
    
    private Vector2 NormalizedMousePos(Vector2 pos)
    {
        Vector2 res = new Vector2(Screen.width, Screen.height);
        return (pos / res);
    }

    private void OnEnable()
    {
        inputs.BatMap.Enable();
        TouchSimulation.Enable();
    }
    
    private void OnDisable()
    {
        inputs.BatMap.Disable();
    }
}
