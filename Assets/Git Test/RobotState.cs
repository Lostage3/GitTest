using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotState : MonoBehaviour
{
    public Robot robot;

    public float idleTimer = 0f;
    public float movementTimer = 5f;
    public float instanceTimer = 0;
    public float maxTime = 2;
    public int collectibleCount;

    public GameObject collectObject;
    public virtual void OnStateEnter()
    {

    }
    public virtual void OnUpdate()
    {

    }
    public virtual void OnStateExit()
    {

    }
}

public class Idle : RobotState
{
    
    public override void OnStateEnter()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public override void OnStateExit()
    {
        Debug.Log("Idle > Hor");
    }

    public override void OnUpdate()
    {
        idleTimer += Time.deltaTime;
        if (idleTimer >= movementTimer)
        {
            robot.SwitchState(new Movement());
        }
    }
}

public class Movement : RobotState
{
    
    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override void OnUpdate()
    {
        if (collectObject != null)
        {
            transform.position += new Vector3(collectObject.transform.position.x, 0, collectObject.transform.position.z);
            if(transform.position == collectObject.transform.position)
            {
                robot.SwitchState(new Collect());
                Debug.Log("Hor > Collect");
            }
        }
        else
        {
            robot.SwitchState(new ColorChange());
            Debug.Log("Hor > ColorChange");
        }
    }
}

public class Collect : RobotState
{
   
    public override void OnStateEnter()
    {
        Destroy(collectObject);
    }

    public override void OnStateExit()
    {

    }

    public override void OnUpdate()
    {
        instanceTimer += Time.deltaTime;
        if (instanceTimer >= maxTime)
        {
            if (collectObject != null)
            {
                
                robot.SwitchState(new Count());
                Debug.Log("Collect > Count");
            }
            else
            {
                robot.SwitchState(new ColorChange());
                Debug.Log("Collect > ColorChange");
            }
        }
    }
}

public class Count : RobotState
{
   
    public override void OnStateEnter()
    {
        collectibleCount++;
    }

    public override void OnStateExit()
    {
        Debug.Log("Count > ColorChange");
    }

    public override void OnUpdate()
    {
        instanceTimer += Time.deltaTime;
        if (instanceTimer >= maxTime)
        {
            
            robot.SwitchState(new ColorChange());
            
        }
    }
}

public class ColorChange : RobotState
{
  
    public override void OnStateEnter()
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    public override void OnStateExit()
    {
        Debug.Log("ColorChange > Idle");
    }

    public override void OnUpdate()
    {
        instanceTimer += Time.deltaTime;
        if (instanceTimer >= maxTime)
        {
            
            robot.SwitchState(new Idle());
            
        }
    }
}

