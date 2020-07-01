using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CountRobot : MonoBehaviour
{
    float idleTimer = 0f;
    public float movementTimer = 5f;
    float instanceTimer = 0;
    public float maxTime = 2;
    public int collectibleCount;
    public float speed = 2;

    public GameObject collectObject;

    public enum State { Idle, Horizontal, Vertical, Collect, Count, ColorChange}

    public State state;

    private void Start()
    {
        
    }
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Horizontal:
                HorMovement();
                break;
            case State.Vertical:
                Jump();
                break;
            case State.Collect:
                Collect();
                break;
            case State.Count:
                Count();
                break;
            case State.ColorChange:
                ColorChange();
                break;
            default:
                break;
        }
    }

    private void Idle()
    {
        idleTimer += Time.deltaTime;
            if(idleTimer >= movementTimer)
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
            state = State.Horizontal;
            idleTimer = 0;
            Debug.Log("Idle > Hor");
        }
    }

    private void HorMovement()
    {
        if (collectObject != null)
        {
            transform.position += new Vector3(collectObject.transform.position.x, 0, collectObject.transform.position.z);
            if (transform.position.x == collectObject.transform.position.x && transform.position.y != collectObject.transform.position.y && transform.position.z == collectObject.transform.position.z)
            {
                state = State.Vertical;
                Debug.Log("Hor > Jump");
            }
            if (transform.position == collectObject.transform.position)
            {
                transform.position += new Vector3(0, 0, 0);
                state = State.Collect;
                Debug.Log("Hor > Collect");
            }
        }
        else
        {
            state = State.ColorChange;
            Debug.Log("Hor > ColorChange");
            instanceTimer = 0;
        }

    }

    private void Jump()
    {
        if (collectObject != null)
        {
            transform.position += new Vector3(0, collectObject.transform.position.y, 0);
            instanceTimer += Time.deltaTime;
            if (instanceTimer >= maxTime)
            {
                if (transform.position.x == collectObject.transform.position.x & transform.position.y == collectObject.transform.position.y & transform.position.z == collectObject.transform.position.z)
                {
                    state = State.Collect;
                    Debug.Log("Jump > Collect");
                    instanceTimer = 0;
                }
            }
        }
        else
        {
            state = State.ColorChange;
            Debug.Log("Jump > ColorChange");
            instanceTimer = 0;
        }

    }

    private void Collect()
    {
        instanceTimer += Time.deltaTime;
        if (instanceTimer >= maxTime)
        {
            if (collectObject != null)
            {
                Destroy(collectObject);
                state = State.Count;
                Debug.Log("Collect > Count");
                instanceTimer = 0;
            }
            else
            {
                state = State.ColorChange;
                Debug.Log("Collect > ColorChange");
                instanceTimer = 0;
            }
        }
    }

    private void Count()
    {
        instanceTimer += Time.deltaTime;
        if (instanceTimer >= maxTime)
        {
            collectibleCount++;
            state = State.ColorChange;
            Debug.Log("Count > ColorChange");
            instanceTimer = 0;
        }
    }

    private void ColorChange()
    {
        instanceTimer += Time.deltaTime;
        if (instanceTimer >= maxTime)
        {
            GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            state = State.Idle;
            Debug.Log("ColorChange > Idle");
            instanceTimer = 0;
        }
    }
}
