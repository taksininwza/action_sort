using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float[] paddingLRTB = new float[4] { 0.5f, 0.5f, 0.5f, 0.5f };
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        initBound();
    }

    private void initBound()
    {
        Camera camera = Camera.main;
        minBounds = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = camera.ViewportToWorldPoint(new Vector2(1, 1));
        minBounds.x += paddingLRTB[0];
        maxBounds.x -= paddingLRTB[1];
        maxBounds.y -= paddingLRTB[2];
        minBounds.y += paddingLRTB[3];
    }

    void OnMove(InputValue inputValue)
    {
        rawInput = inputValue.Get<Vector2>();
    }
    void OnFire(InputValue inputValue)
    {
        if (shooter == null)
            return;
        shooter.isFiring = inputValue.isPressed;
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        Vector3 move = rawInput * speed * Time.deltaTime;
        Vector2 position = transform.position + move;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);
        transform.position = newPosition;
    }
}
