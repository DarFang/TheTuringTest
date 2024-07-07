using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private bool arrivedAtDestination;
    private Vector3 destination;
    private NavMeshAgent agentToCommand;
    public override void Execute()
    {
        agentToCommand.SetDestination(destination);
        if(agentToCommand.remainingDistance <0.5)
        {
            arrivedAtDestination= true;
        }
    }
    public override bool IsCompleted()
    {
        return arrivedAtDestination;
    }
    public MoveCommand(NavMeshAgent agent, Vector3 destination)
    {
        this.agentToCommand= agent;
        this.destination= destination;
    }
}
