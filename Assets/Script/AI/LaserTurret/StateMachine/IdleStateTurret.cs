using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateTurret : AITurretState
{
    public IdleStateTurret(AITurretController contr): base(contr)
    {

    }
    public override void OnStateEnter()
    {

    }


    public override void OnStateRun()
    {
        Debug.Log("Idling (not attacking Player)");
    }
    public override void OnStateExit()
    {
    }
}
