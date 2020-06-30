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
    float moveSpeed;

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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = speed * 2;
        }
        else
        {
            moveSpeed = speed;
        }
        rb.AddForce(new Vector3(hor, 0, ver) * moveSpeed * Time.deltaTime, ForceMode.Impulse);
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
