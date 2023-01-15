using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 rawInput;
    [SerializeField] float speed = 5f;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    private Shooter shooter;


    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    private void InitBounds()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public void OnMove(InputValue input)
    {
        rawInput = input.Get<Vector2>();
    }

    public void OnFire(InputValue input)
    {
        if (shooter != null)
        {
            shooter.isFiring = input.isPressed;
        }
        print(input.isPressed);
    }

    private void Move()
    {
        Vector2 delta = rawInput * Time.deltaTime * speed;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

}
