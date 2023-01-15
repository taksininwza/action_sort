using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    Rigidbody2D rigidbody2d;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rigidbody2d.velocity = new Vector2(moveSpeed, 0);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        flip();
    }

    private void flip()
    {
        float xScale = Mathf.Sign(moveSpeed);
        transform.localScale = new Vector3(xScale, 1, 1);
    }
}
