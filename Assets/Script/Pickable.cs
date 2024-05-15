using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField] private FixedJoint joint;
    public void OnHoverEnter()
    {
        
    }

    public void OnHoverExit()
    {
        
    }

    public void Oninteract()
    {
        Pickup();
    }

    private void Pickup()
    {
        PlayerInput player = FindObjectOfType<PlayerInput>();
        joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = player.GetComponent<Rigidbody>();
    }
    private void Drop()
    {

    }
}
