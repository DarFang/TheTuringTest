using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorKey : MonoBehaviour
{
    [SerializeField] private UnityEvent OnKeyPickedUp;

    private void OnTriggerEnter(Collider other) 
    {
        OnKeyPickedUp?.Invoke();
        Debug.Log("KeyPickedup");
        Destroy(gameObject);
    }
}
