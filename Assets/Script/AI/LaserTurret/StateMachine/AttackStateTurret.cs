using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateTurret : AITurretState
{
    HealthModule healthModule;
    private float dmgPerSec;
    public AttackStateTurret(
        AITurretController contr, 
        HealthModule healthModule,
        float dmgPerSec) : base(contr)
    {
        this.healthModule = healthModule;
        this.dmgPerSec = dmgPerSec;
    }
    public override void OnStateEnter()
    {
        
    }
    public override void OnStateRun()
    {
        Debug.Log("Attacking Player");
        healthModule.DeductHealth(dmgPerSec*Time.deltaTime);        
    }
    public override void OnStateExit()
    {

    }

}
