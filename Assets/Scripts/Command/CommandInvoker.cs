using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    // Collected commands
    protected Queue<Command> commandBuffer = new Queue<Command>();

    // Method to add new command to buffer
    public virtual void AddCommand(Command newCommand)
    {
        commandBuffer.Enqueue(newCommand);
    }

    public virtual void ExecuteBuffer()
    {
        foreach(var command in commandBuffer)
        {
            command.Execute();
        }

        commandBuffer.Clear();
    }
}
