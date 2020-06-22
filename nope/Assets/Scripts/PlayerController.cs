﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed = 5f;
    public float JumpSpeed = 4f;

    private Rigidbody2D rb;
    private Animator anim;

    public GroundCheck GC;
    public Transform Body;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //check for player motion
        if (rb.velocity.x != 0) anim.SetBool("Walking", true);
        else anim.SetBool("Walking", false);

        if(GC.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Jumping", true);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //calc for to add to player for WalkSpeed
        float F = ((WalkSpeed * h - rb.velocity.x) / Time.deltaTime) * rb.mass; //((V - Vi)/time) *mass
        rb.AddForce(new Vector2(F, 0));

        if (h > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (h < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Jump()
    {
        if (GC.isGrounded)
        {
            float F = JumpSpeed; // ((JumpSpeed - rb.velocity.y) / Time.deltaTime) * rb.mass;
            rb.velocity = new Vector3(rb.velocity.x, F, 0);
        }
    }
}
