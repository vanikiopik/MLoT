using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Move()
    {
        //Stupid realisation of character movement NEED TO FIX
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(1f, rb.velocity.y);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-1f, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0f, 4f);
        }
    }


    void Update()
    {
        if (rb.velocity.y == 0)
        {
            Jump();
        }

        Move();
    }
}
