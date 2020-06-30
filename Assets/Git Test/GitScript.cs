using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitScript : MonoBehaviour
{
    public float speed = 0.1f;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        transform.position += new Vector3(hor, 0, ver) * speed * Time.deltaTime;
    }
}
