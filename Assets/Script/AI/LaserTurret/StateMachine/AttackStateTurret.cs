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
        Debug.Log("Attacking Player");
        healthModule.DeductHealth(controller.dmgPerSec*Time.deltaTime);        
    }
    public override void OnStateExit()
    {
        controller.turretVision.OnTargetLost.RemoveListener(NextState);
    }
    private void NextState()
    {
        Debug.Log("NextState to idle");
        controller.ChangeState(new IdleStateTurret(controller));
    }
}
