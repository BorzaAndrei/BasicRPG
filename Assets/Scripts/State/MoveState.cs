using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    private Vector2 targetPosition;

    public override void PrepareState()
    {
        base.PrepareState();

        targetPosition = new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-2.0f, 2.0f));
    }

    public override void UpdateState()
    {
        base.UpdateState();

        var direction = targetPosition - new Vector2(owner.transform.position.x, owner.transform.position.y);
        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }
        owner.Movement.Move(direction);

        if (direction.magnitude < 0.2f)
        {
            owner.ChangeState(new WaitState());
        }
    }
}
