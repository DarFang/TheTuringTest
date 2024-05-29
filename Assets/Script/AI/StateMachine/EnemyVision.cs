using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private AIController myController;
    private void OnTriggerEnter(Collider other)
    {
        myController.ChangeState(new ChaseState(myController, other.transform));
        Debug.Log("PlayerEntered");
    }
    private void OnTriggerExit(Collider other)
    {
        myController.ChangeState(new PatrolState(myController));
        Debug.Log("PlayerExitedTrigger");
    }
}
