using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleMovementC : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector2 destination;

    [SerializeField]
    public float moveSpeed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0;
        destination = rb.position;
    }

    private void FixedUpdate()
    {
        var input = destination - rb.position;
        if (input.magnitude > 1)
        {
            input.Normalize();
        }
        input *= moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + input);
    }

    public void Move(Vector2 destination)
    {
        this.destination = destination;
    }
}
