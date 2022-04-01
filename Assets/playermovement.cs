using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Transform groundcheck;
    float grounddistance = 0.4f;
    public float movespeed = 0.1f;
    float gravity = -9.81f;
    bool grounded = false;
    public LayerMask ground;
    Vector3 velocity;
    public CharacterController cr;
    

    
    void Update()
    {
        grounded = Physics.CheckSphere(groundcheck.position, grounddistance, ground);

        if (grounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        
        if (Input.GetKey("space") && grounded)
        {
            velocity.y = 5;
        }
        if (Input.GetKey("w"))
        {
            cr.Move(transform.forward * movespeed);
        }
        if (Input.GetKey("s"))
        {
            cr.Move(-transform.forward * movespeed);
        }
        if (Input.GetKey("a"))
        {
            cr.Move(-transform.right * movespeed);
        }
        if (Input.GetKey("d"))
        {
            cr.Move(transform.right * movespeed);
        }
        cr.Move(velocity * Time.deltaTime);
    }
    
}
