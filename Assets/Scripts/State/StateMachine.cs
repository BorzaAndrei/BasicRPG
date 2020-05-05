using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    private BaseState currentState;

    [SerializeField]
    private SimpleMovement movement;
    public SimpleMovement Movement => movement;

    // Start is called before the first frame update
    void Start()
    {
        var waitState = new WaitState();
        waitState.minWait = 1;

        ChangeState(waitState);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.DestroyState();
        }
        currentState = newState;

        if (currentState != null)
        {
            currentState.owner = this;
            currentState.PrepareState();
        }
    }


}
