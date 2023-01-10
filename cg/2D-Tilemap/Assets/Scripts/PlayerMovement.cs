using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed = new Vector2(10, 10);
    Rigidbody2D rigidbody2d;
    CapsuleCollider2D collider2d;
    Animator animator;
    Vector2 moveInput;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2d = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
        run();
    }
    bool isOnGround
    {
        get
        {
            int groundLayer = LayerMask.GetMask("Ground");
            return collider2d.IsTouchingLayers(groundLayer);
        }
    }
    bool isHorizontalMoving
    {
        get
        {
            return Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;
        }
    }

    private void flipSprite()
    {
        if (isHorizontalMoving)
        {
            float xScale = Mathf.Sign(rigidbody2d.velocity.x) * Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }

    }

    private void run()
    {
        float xAxis = moveInput.x * moveSpeed.x;
        float yAxis = rigidbody2d.velocity.y;
        Vector2 velocity = new Vector2(xAxis, yAxis);
        rigidbody2d.velocity = velocity;
        animator.SetBool("IsRunning", isHorizontalMoving);
        flipSprite();
        jumpAnimation();
    }

    private void jumpAnimation()
    {
        if (animator.GetBool("IsJumping") && rigidbody2d.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
        if (animator.GetBool("IsFalling") && isOnGround)
        {
            animator.SetBool("IsFalling", false);
        }
    }

    void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed && isOnGround)
        {
            Vector2 velocity = new Vector2(0f, moveSpeed.y);
            rigidbody2d.velocity += velocity;
            animator.SetBool("IsJumping", true);
        }
    }
}
