using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] target;
    
    private AiState currentState;
    void Start()
    {
        currentState = new PatrolState(this);
        currentState.OnStateEnter();   
    }
    void Update()
    {

       currentState.OnStateRun();   
    }
    public void ChangeState(AiState state)
    {
        if(currentState !=null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        currentState.OnStateEnter();
    }
    public NavMeshAgent GetAgent()
    {
        return agent;
    }
    public Transform[] getPath()
    {
        return target;
    }

}
