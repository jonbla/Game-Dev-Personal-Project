using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 delta;

    MainControls controls;

    public void Awake()
    {
        controls = new MainControls();
        controls.Player.Move.performed += ctx => delta = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => delta = Vector2.zero;
    }

    private void Update()
    {
        Move();
    }

    void CalculateMovement()
    {
        delta = delta * Time.deltaTime * speed;
    }

    public void Move()
    {

        print(delta);
        CalculateMovement();
        Vector2 m = new Vector2(delta.x, delta.y);
        transform.Translate(m, Space.World);
    }
}
