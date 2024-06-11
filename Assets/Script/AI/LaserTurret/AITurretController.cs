using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class AITurretController : MonoBehaviour
{
    public AITurretState currentState {get; private set;}

    void Start()
    {
        currentState = new IdleStateTurret(this);
        currentState.OnStateEnter();
          
    }

    // Update is called once per frame
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
}
