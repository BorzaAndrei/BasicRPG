using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    // Reference to our state machine
    public StateMachine owner;

    // Method called to prepare state to operate - same as Unity's Start()
    public virtual void PrepareState() { }


    // Method called to update state on every frame - same as Unity's Update()
    public virtual void UpdateState() { }

    // Method called to destroy state - same as Unity's OnDestroy()
    public virtual void DestroyState() { }
}
