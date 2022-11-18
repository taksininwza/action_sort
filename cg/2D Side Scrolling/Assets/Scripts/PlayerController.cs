using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 50f;
    [SerializeField] float normalSpeed = 5;
    [SerializeField] float boostSpeed = 15;
    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D _rigidbody2D;

    private void Start()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        RotatePlayer();
        BoostUpPlayer();
    }

    private void BoostUpPlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //boost speed
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            //normal speed
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rigidbody2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rigidbody2D.AddTorque(-torqueAmount);
        }
    }
}
