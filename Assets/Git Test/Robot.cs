using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public RobotState currentState;
    

    public void Start()
    {
       
    }
    public void SwitchState(RobotState robotState)
    {
        currentState.OnStateExit();
        currentState = robotState;
        currentState.robot = this;
        currentState.OnStateEnter();
    }
    private void Update()
    {
        currentState.OnUpdate();
    }
}
