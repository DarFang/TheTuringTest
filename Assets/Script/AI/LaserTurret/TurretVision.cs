using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretVision : MonoBehaviour
{
    public UnityEvent OnTargetSeen;
    public UnityEvent OnTargetLost;
    public HealthModule health {get; private set;}
    [SerializeField] private AITurretController myController;
    [SerializeField] private Transform LaserStart;
    [SerializeField] private float LaserRange = 2f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask OtherLayers;
    [SerializeField] private LineRenderer lineRenderer;
    private void Awake() 
    {
        myController.LinkToTurretVision(this);    
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(LaserStart.position, LaserStart.transform.forward, out hit, LaserRange, OtherLayers))
        {
            lineRenderer.SetPosition(1, hit.point);
            if(health != null)
            {
                OnTargetLost?.Invoke();
                health = null;
            }
        }
        else if (Physics.Raycast(LaserStart.position, LaserStart.transform.forward, out hit, LaserRange, playerLayer))
        {
            lineRenderer.SetPosition(1, hit.point);
            if(health == null)
            {
                health = hit.collider.gameObject.GetComponent<HealthModule>();
                OnTargetSeen?.Invoke();   
            }
        }
        else
        {
            lineRenderer.SetPosition(1, LaserStart.position + LaserStart.transform.forward * LaserRange);
             if(health != null)
            {
                OnTargetLost?.Invoke();
                health = null;
            }
        }
        lineRenderer.SetPosition(0, LaserStart.position);
    }
}
