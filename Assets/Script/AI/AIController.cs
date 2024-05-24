using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] target;
    [SerializeField] private int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(target[0].position);
    }

    // Update is called once per frame
    void Update()
    {

        if(agent.remainingDistance < agent.stoppingDistance)
        {
            Debug.Log("new point");
            wayPointIndex++;
            if(wayPointIndex >= target.Length)
            {
                wayPointIndex = 0;
            }

            agent.SetDestination(target[wayPointIndex].position);
        }
    }
}
