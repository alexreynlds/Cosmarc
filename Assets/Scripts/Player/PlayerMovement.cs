using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementInput;

    Rigidbody2D rb;

    private float moveSpeed;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = GetComponent<PlayerStats>().moveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

                if (!success)
                {
                    TryMove(new Vector2(0, movementInput.y));
                }
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        int count =
            rb
                .Cast(direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.deltaTime + collisionOffset);

        if (count == 0)
        {
            rb
                .MovePosition(rb.position +
                direction * moveSpeed * Time.deltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnTest()
    {
        GetComponent<PlayerStats>().currentHealth -= 1;
    }

    void OnTest2()
    {
        GetComponent<PlayerStats>().maxHealth += 2;
    }
}
