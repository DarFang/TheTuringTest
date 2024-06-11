using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVision : MonoBehaviour
{
    [SerializeField] private AITurretController myController;
    [SerializeField] private Transform LaserStart;
    [SerializeField] private float LaserRange = 2f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask OtherLayers;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] private float damagePerSec = 10f;
    private bool hasSeenPlayer;
    void Start()
    {
        
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(LaserStart.position,Vector3.forward, out hit, LaserRange, OtherLayers))
        {
            lineRenderer.SetPosition(1, hit.point);
            hasSeenPlayer = false;
        }
        else if (Physics.Raycast(LaserStart.position, Vector3.forward, out hit, LaserRange, playerLayer))
        {
            lineRenderer.SetPosition(1, hit.point);
            hasSeenPlayer = true;
        }
        else
        {
            lineRenderer.SetPosition(1, LaserStart.position + Vector3.forward * LaserRange);
            hasSeenPlayer = false;
        }
        lineRenderer.SetPosition(0, LaserStart.position);
        if(hasSeenPlayer && myController.currentState is IdleStateTurret)
        {
            HealthModule health = hit.collider.gameObject.GetComponent<HealthModule>();
            myController.ChangeState(new AttackStateTurret(myController, health, damagePerSec));
        }
        else if(!hasSeenPlayer && myController.currentState is AttackStateTurret)
        {
            myController.ChangeState(new IdleStateTurret(myController));
        }
    }
}
