using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed = new Vector2(10, 10);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Rigidbody2D rigidbody2d;
    CapsuleCollider2D bodyCollider2d;
    BoxCollider2D feetCollider2d;
    Animator animator;
    Vector2 moveInput;
    bool isAlive = true;
    int enemyLayerMask;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider2d = GetComponent<CapsuleCollider2D>();
        feetCollider2d = GetComponent<BoxCollider2D>();
        enemyLayerMask = LayerMask.GetMask("Enemies", "Hazards");
    }
    private void Update()
    {
        if (isAlive == false)
        {
            float turnSpeed = 8 * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), turnSpeed);
            animator.Play("Player Fall");
            return;
        };
        run();
        die();
    }

    private void die()
    {
        if (bodyCollider2d.IsTouchingLayers(enemyLayerMask))
        {
            isAlive = false;
            GameSession.Instance.OnPlayerDeath();
        }
    }

    bool isOnGround
    {
        get
        {
            int groundLayer = LayerMask.GetMask("Ground");
            return feetCollider2d.IsTouchingLayers(groundLayer);
        }
    }
    bool isFalling
    {
        get
        {
            return rigidbody2d.velocity.y < 0;
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
        jumpingAnimation();
        fallingAnimation();
    }

    private void fallingAnimation()
    {
        animator.SetBool("IsFalling", (isFalling && !isOnGround));
    }

    private void jumpingAnimation()
    {
        if (animator.GetBool("IsJumping") && isFalling)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
    }

    void OnMove(InputValue inputValue)
    {
        if (isAlive == false) return;
        moveInput = inputValue.Get<Vector2>();
    }

    void OnJump(InputValue inputValue)
    {
        if (isAlive == false) return;
        if (inputValue.isPressed && isOnGround)
        {
            Vector2 velocity = new Vector2(0f, moveSpeed.y);
            rigidbody2d.velocity += velocity;
            animator.SetBool("IsJumping", true);
        }
    }

    void OnFire(InputValue inputValue)
    {
        if (isAlive == false) return;
        float xScale = Mathf.Sign(transform.localScale.x);
        bullet.transform.localScale = new Vector3(xScale, 1, 1);
        Instantiate(bullet, gun.position, transform.rotation);
    }
}
