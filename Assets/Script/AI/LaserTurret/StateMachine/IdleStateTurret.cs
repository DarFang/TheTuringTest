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
        controller.turretVision.OnTargetSeen.AddListener(NextState);
    }
    public override void OnStateRun()
    {
        Debug.Log("Idling (not attacking Player)");
    }
    public override void OnStateExit()
    {
        controller.turretVision.OnTargetSeen.RemoveListener(NextState);
    }
    private void NextState()
    {
        Debug.Log("NextState to attack");
        controller.ChangeState(new AttackStateTurret(controller, controller.turretVision.health));
    }
}
