using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretVision : MonoBehaviour
{
    [SerializeField] private AITurretController myController;
    [SerializeField] private Transform LaserStart;
    [SerializeField] private float LaserRange = 2f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask OtherLayers;
    [SerializeField] LineRenderer lineRenderer;
    public UnityEvent OnTargetSeen;
    public UnityEvent OnTargetLost;
    public HealthModule health {get; private set;}
    private void Awake() 
    {
        myController.LinkToTurretVision(this);    
    }
    void Start()
    {

    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(LaserStart.position,Vector3.forward, out hit, LaserRange, OtherLayers))
        {
            lineRenderer.SetPosition(1, hit.point);
            OnTargetLost?.Invoke();
            health = null;
        }
        else if (Physics.Raycast(LaserStart.position, Vector3.forward, out hit, LaserRange, playerLayer))
        {
            lineRenderer.SetPosition(1, hit.point);
            health = hit.collider.gameObject.GetComponent<HealthModule>();
            OnTargetSeen?.Invoke();   
        }
        else
        {
            lineRenderer.SetPosition(1, LaserStart.position + Vector3.forward * LaserRange);
            OnTargetLost?.Invoke();
            health = null;
        }
        lineRenderer.SetPosition(0, LaserStart.position);
    }
}
