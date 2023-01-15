using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 1.5f;
    float actualSpeed;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        actualSpeed = Mathf.Sign(transform.localScale.x) * speed;
    }
    private void Update()
    {
        rigidbody2d.velocity = new Vector2(actualSpeed, 0);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(this.gameObject);
    }
}
