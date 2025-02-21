using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AiState
{
    private Transform targetToChase;
    public ChaseState(AIController contr, Transform target) : base(contr)
    {
        this.targetToChase = target;
    }
    public override void OnStateEnter()
    {
        
    }
    public override void OnStateExit()
    {
        
    }
    public override void OnStateRun()
    {
        controller.GetAgent().SetDestination(targetToChase.position);
        //set desination to player position
         if(controller.GetAgent().remainingDistance < controller.GetAgent().stoppingDistance)
        {
            //change state to attack
            Debug.Log("reached");
        }
    }
}
