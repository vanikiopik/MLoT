using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;

    // Fields for isGrounded method
    public bool isGrounded;
    public Transform groundCheck;
    private float checkRadius = 0.8f;
    public LayerMask whatIsGround;

    // Fields for double-jumps
    public int allowJumps;
    private int jumpCount = 2;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpCount = 0;
    }


    void Move()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(1f, rb.velocity.y);
            animator.SetInteger("Dir", 1);  // Sets the animation
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-1f, rb.velocity.y);
            transform.localRotation = Quaternion.Euler(0, 180, 0);  // Rotating sprite to other side
            animator.SetInteger("Dir", -1);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            animator.SetInteger("Dir", 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // First jump
            if (isGrounded)
            {
                rb.velocity = new Vector2(0f, 4f);
            }
            // Second jump
            else if (jumpCount < allowJumps - 1)
            {
                rb.velocity = new Vector2(0f, 4f);
                jumpCount++;
            }
        }
    }


    void Update()
    {
        Jump();
        Move();
    }


    void FixedUpdate()
    {
        //State for checking object collision on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }
}
