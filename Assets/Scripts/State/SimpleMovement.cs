using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    private Vector2 input;

    [SerializeField]
    private float moveSpeed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        input *= moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + input);
    }

    public void Move(Vector2 input)
    {
        if (input.magnitude > 1)
        {
            input.Normalize();
        }
        this.input = input;
        
    }
}
