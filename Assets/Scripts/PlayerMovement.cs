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
    
    void Update()
    {
        //Stupid realisation of character movement NEED TO FIX
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(1f, 0f);
        }        
        else if(Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-1f, 0f);
        }
    }
}
