using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AiState
{
    [SerializeField] private int wayPointIndex = 0;

    public PatrolState(AIController contr) : base(contr)
    {
    }

    public override void OnStateEnter()
    {
       controller.GetAgent().SetDestination(controller.getPath()[wayPointIndex].position);
    }

    public override void OnStateExit()
    {
       
    }

    public override void OnStateRun()
    {
         if(controller.GetAgent().remainingDistance < controller.GetAgent().stoppingDistance)
        {
            Debug.Log("new point");
            wayPointIndex++;
            if(wayPointIndex >= controller.getPath().Length)
            {
                wayPointIndex = 0;
            }
            controller.GetAgent().SetDestination(controller.getPath()[wayPointIndex].position);
        }
    }

 

}
