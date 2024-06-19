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
    }
    public override void OnStateExit()
    {
        controller.turretVision.OnTargetSeen.RemoveListener(NextState);
    }
    public override void NextState()
    {
        controller.ChangeState(new AttackStateTurret(controller, controller.turretVision.health));
    }
}
