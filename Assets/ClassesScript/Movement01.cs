using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement01 : AbstrakteKlasse
{
    float jumpHeight = 30f;
    public override float JumpHeight
    {
        get
        {
            return jumpHeight;
        }
        set
        {
            jumpHeight = value;
        }
    }
    Vector3 jumpDirection = new Vector3(0, 1, 0);
    public override Vector3 JumpDirection
    {
        get
        {
            return jumpDirection;
        }
        set
        {
            jumpDirection = value;
        }
    }
    float moveSpeed = 0.3f;
    public override float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }
    Vector3 moveDirection = new Vector3(1, 0, 0);
    public override Vector3 MoveDirection
    {
        get
        {
            return moveDirection;
        }
        set
        {
            moveDirection = value;
        }
    }
    public GameObject o;
    public override GameObject Object
    {
        get
        {
            return o;
        }
        set
        {
            o = value;
        }
    }

    public override void Jump()
    {
        o.transform.position += jumpDirection * jumpHeight;
    }

    public override void Movement()
    {
        o.transform.position += moveDirection * moveSpeed;
    }
}
