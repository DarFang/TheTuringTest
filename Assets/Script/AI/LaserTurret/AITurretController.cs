using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class AITurretController : MonoBehaviour
{
    public AITurretState currentState {get; private set;}
    public TurretVision turretVision{get; private set;}
    [field: SerializeField] public float dmgPerSec {get; private set;} = 10f;

    void Start()
    {
        currentState = new IdleStateTurret(this);
        currentState.OnStateEnter();
    }
    void Update()
    {
        currentState.OnStateRun();   
    }
    public void ChangeState(AITurretState state)
    {
        Debug.Log("State changed");
        if(currentState !=null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        currentState.OnStateEnter();
    }
    public void LinkToTurretVision(TurretVision turretVision)
    {
        this.turretVision = turretVision;
    }
}
