using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : MonoBehaviour
{
    [SerializeField]private float leftCap;
    [SerializeField]private float rightCap;
    private Quaternion fixedRotation;
    public LayerMask ground;

    [SerializeField]private float jumpLength = 5f;
    [SerializeField]private float jumpHeight = 5f;
    
    private bool facingLeft = true;
    private Collider2D coll;
    private Rigidbody2D rb;

    private void Start()
    {
        fixedRotation = transform.rotation;
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.rotation = fixedRotation;
        if (facingLeft == true)
        {
            //test if we are beyonded the leftCap
            if (transform.position.x > leftCap)
            {
                //make sure sprite is facing left
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }

                //test if frog on the ground, if so then jump left
                if (coll.IsTouchingLayers(ground))
                {
                    Debug.Log("jump left");
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                }
            }
            else
            {
                //if not we are going to face right
                facingLeft = false;
            }
        }
        else
        {
            if (transform.localScale.x != -1)
            {
                transform.localScale = new Vector3(-1, 1);
            }
            Debug.Log("facing right");
            if (facingLeft == false && transform.position.x < rightCap)
            {
                //test if frog on the ground, if so then jump right
                if (coll.IsTouchingLayers(ground))
                {
                    Debug.Log("jump right");
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                }
            }
            else
            {
                //if not we are going to face left
                facingLeft = transform;
                transform.localScale = new Vector2(1, 1);
                facingLeft = true;
                Debug.Log("facing left");
            }
        }
    }

}
