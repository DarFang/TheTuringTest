using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractModule : MonoBehaviour
{
    [Header("Interactions")]
    [SerializeField] private Transform pickupPoint;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] Camera camera;
    private IInteractable targetInteractable;
    public void InteractWithObject()
    {
        if(targetInteractable != null)
        {
            targetInteractable.OnInteract(this);
        }
    }
    private void Update() 
    {
        Interact();
    }
    void Interact()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 4f, interactableLayer ))
        {
            if(targetInteractable == null){
                targetInteractable = hit.collider.GetComponent<IInteractable>();
                if(targetInteractable != null)
                {
                    targetInteractable.OnHoverEnter();
                }
            }
        }
        else if(targetInteractable != null)
        {
            targetInteractable.OnHoverExit();
            targetInteractable = null;
        }
    }
    public Transform GetPickupTransform()
    {
        return pickupPoint;
    }
}
