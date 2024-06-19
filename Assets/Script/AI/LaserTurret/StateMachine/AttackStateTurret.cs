using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateTurret : AITurretState
{
    HealthModule healthModule;
    public AttackStateTurret(
        AITurretController contr, 
        HealthModule healthModule) : base(contr)
    {
        this.healthModule = healthModule;
    }
    public override void OnStateEnter()
    {
        controller.turretVision.OnTargetLost.AddListener(NextState);
    }
    public override void OnStateRun()
    {
        healthModule.DeductHealth(controller.dmgPerSec*Time.deltaTime);        
    }
    public override void OnStateExit()
    {
        controller.turretVision.OnTargetLost.RemoveListener(NextState);
    }
    public override void NextState()
    {
        controller.ChangeState(new IdleStateTurret(controller));
    }
}
