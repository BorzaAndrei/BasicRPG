using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : BaseState
{
    public float minWait = 1;

    private float waitTime;

    public override void PrepareState()
    {
        base.PrepareState();

        waitTime = Random.Range(minWait, 2.5f);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        waitTime -= Time.deltaTime;

        if (waitTime < 0)
        {
            owner.ChangeState(new MoveState());
        }
    }
}
