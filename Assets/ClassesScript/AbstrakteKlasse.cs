using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstrakteKlasse
{
    public abstract float JumpHeight { get; set; }
    public abstract Vector3 JumpDirection { get; set; }
    public abstract float MoveSpeed { get; set; }
    public abstract Vector3 MoveDirection { get; set; }
    public abstract GameObject Object { get; set; }

    public abstract void Jump();
    public abstract void Movement();
    
    
}
