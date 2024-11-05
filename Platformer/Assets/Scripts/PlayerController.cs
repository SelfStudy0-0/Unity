using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Start() var
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    public int cherries = 0;
    public Text cherryText;

    //FSM
    private enum State{idle,running,jumping,falling};
    private State state = State.idle;
    //Inspector variable
    public LayerMask ground;
    public float speed = 5f;
    public float jumpForce = 15f;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    
    }
  
    // Update is called once per frame
    void Update()
    {
        Movement();
        AnimationState();
        anim.SetInteger("state", (int)state);//sets animation based on Enumerator state
        //Debug.Log((int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable")) 
        {
            cherries += 1;
            Destroy(collision.gameObject);
            //Debug.Log(cherries);
            cherryText.text = cherries.ToString();
        }
    }
    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection < 0)
        {
            //moving left
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (hDirection > 0)
        {
            //moveing right
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //jump
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }
    }

    private void AnimationState()
    {
        if(state == State.jumping)
        {
           //state = State.idle;
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            } 
        }
        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if(Math.Abs(rb.velocity.x) > 4.5f)
        {
            //is running
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
        //Debug.Log(state);
    }
}
