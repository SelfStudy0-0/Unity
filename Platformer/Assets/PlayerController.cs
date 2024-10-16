using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private enum State{idle,running,jumping};
    private State state = State.idle;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
  
    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");

        //left�Bright movement
       if (hDirection < 0) 
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
       else if (hDirection > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

       //jump
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
            state = State.jumping;
        }
        VelocityState();
        anim.SetInteger("state",(int)state);
    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {
            state = State.idle;
        }
        else if(Math.Abs(rb.velocity.x) > 2f)
        {
            //is running
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }
}
