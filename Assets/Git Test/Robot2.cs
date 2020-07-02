using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot2 : MonoBehaviour
{
    RobotStatePattern currentPattern;
    
    public void SwitchPattern(RobotStatePattern pattern)
    {
        currentPattern.OnPatternExit();
        currentPattern = pattern;
        currentPattern.robot = this;
        currentPattern.OnPatternEnter();

    }
    public void Update()
    {
        currentPattern.OnUpdate();
    }
}

public class RobotStatePattern
{
    public Robot2 robot;

    public virtual void OnPatternEnter()
    {

    }
    public virtual void OnPatternExit()
    {

    }
    public virtual void OnUpdate()
    {

    }
}

public class IdlePattern : RobotStatePattern
{
    float timer; 
    public override void OnPatternEnter()
    {
        
    }

    public override void OnPatternExit()
    {
        Debug.Log("Idle > Move");
    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
            if (timer >= 3)
        {
            robot.SwitchPattern(new MovementPattern());
        }
    }
}

public class MovementPattern : RobotStatePattern
{
    public override void OnPatternEnter()
    {

    }

    public override void OnPatternExit()
    {

    }

    public override void OnUpdate()
    {

    }
}

public class CollectPattern : RobotStatePattern
{
    public override void OnPatternEnter()
    {

    }

    public override void OnPatternExit()
    {

    }

    public override void OnUpdate()
    {

    }
}

public class CountPattern : RobotStatePattern
{
    public override void OnPatternEnter()
    {

    }

    public override void OnPatternExit()
    {

    }

    public override void OnUpdate()
    {

    }
}

public class ColorPattern : RobotStatePattern
{
    public override void OnPatternEnter()
    {

    }

    public override void OnPatternExit()
    {

    }

    public override void OnUpdate()
    {

    }
}