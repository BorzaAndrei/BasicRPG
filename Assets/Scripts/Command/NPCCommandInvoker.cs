using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCommandInvoker : CommandInvoker
{

    public Transform[] targets;
    public float timeBetweenCommands;
    public SimpleMovementC simpleMovement;
    private float lastExecution;
    private bool executeCommands;

    public override void ExecuteBuffer()
    {
        executeCommands = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (targets.Length == 0)
        {
            targets = new Transform[] { PlayerController.instance.transform };
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (executeCommands && commandBuffer.Count > 0)
        {
            var diff = Time.time - lastExecution;
            //Debug.Log(diff.ToString() + " " + timeBetweenCommands.ToString());
            if (diff > timeBetweenCommands)
            {
                lastExecution = Time.time;
                var c = commandBuffer.Dequeue();
                c.Execute();

                executeCommands = commandBuffer.Count != 0;
            }
        }

        if (!executeCommands)
        {
            InitializeCommands();
            ExecuteBuffer();
        }
    }

    private void InitializeCommands()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            var c = new MoveCommand();
            c.movement = simpleMovement;
            Vector2 target = new Vector2(targets[i].position.x, targets[i].position.y);
            c.target = target;
            AddCommand(c);
        }
    }
}
