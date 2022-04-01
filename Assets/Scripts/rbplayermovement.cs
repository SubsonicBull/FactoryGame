using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbplayermovement : MonoBehaviour
{
    public Transform groundcheck;
    public Transform cam;
    public Rigidbody rb;
    public float movespeed = 1f;
    bool grounded = false;
    public LayerMask ground;
    RaycastHit hita;
    RaycastHit hitb;
    public float slopelimit = 0.5f;
    void Update()
    {
        grounded = Physics.CheckSphere(groundcheck.position, 0.4f, ground);
        if (grounded && Input.GetKey("space"))
        {
            rb.AddForce(0f, 10, 0f);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.forward * movespeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(-transform.forward * movespeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(transform.right * movespeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-transform.right * movespeed * Time.deltaTime);
        }
        if (!Input.anyKey && grounded)
        {
            rb.velocity = new Vector3(0f,0f,0f);
        }
        while (Physics.Raycast(groundcheck.position, transform.forward,out hita, 1f) && !Physics.Raycast(groundcheck.position, transform.forward + new Vector3(0f, slopelimit, 0f),out hitb, 1f))
        {            
            transform.Translate(new Vector3(0f, 0.1f, 0f));
        }
    }
}
