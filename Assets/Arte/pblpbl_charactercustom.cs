﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pblpbl_charactercustom : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;// = 360f;
    public float jumpForce;//  = 500f;
    public bool jumpAllowed;
    public Animator anim;

    void OnCollisionEnter2D(Collision2D col)
    {
        print(col.gameObject.tag);
        if (col.gameObject.tag.Equals("floor"))
        {
            jumpAllowed = true;
            anim.Play("octopuss_jump");
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("floor"))
        { 
            jumpAllowed = false; 
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpAllowed == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
   
    }
    
}