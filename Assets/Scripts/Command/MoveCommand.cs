using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{

    public Vector2 target;
    public SimpleMovementC movement;

    public override void Execute()
    {
        movement.Move(target);
    }
}
