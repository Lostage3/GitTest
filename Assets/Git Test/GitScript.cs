using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitScript : MonoBehaviour
{
    public float speed = 0.1f;
    Rigidbody rb;
    public float jumpVelocity = 6;
    public bool grounded;
    public GameObject plane;
    public int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    private void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded == true)
            {
                Jump();
            }
        }
    }

    private void Movement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        
        rb.AddForce(new Vector3(hor, 0, ver) * speed * Time.deltaTime, ForceMode.Impulse);
    }
    void Jump()
    {
        rb.AddForce(new Vector3(0, 1, 0) * jumpVelocity, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (plane)
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (plane)
        {
            grounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        count++;
    }
}
