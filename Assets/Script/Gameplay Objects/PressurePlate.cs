using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private UnityEvent OnActivation;
    [SerializeField] private UnityEvent OnDeactivation;
    [SerializeField] private Rigidbody corretRigidbody;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.attachedRigidbody ==  corretRigidbody)
        {
            OnActivation.Invoke();
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.attachedRigidbody ==  corretRigidbody)
        {
            OnDeactivation.Invoke();
        }
    }
}
