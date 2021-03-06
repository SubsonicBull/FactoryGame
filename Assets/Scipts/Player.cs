﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float gravity;
    public CharacterController crcon;
    public Transform groundcheck;
    public float distancetoground;
    public LayerMask ground;
    Vector3 velocity;
    bool isGrounded;
    

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, distancetoground, ground);

        if(isGrounded)
        {
            velocity.y = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        crcon.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        crcon.Move(velocity);
    }
}
