using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorIndicator : MonoBehaviour, IInteractable
{
    [SerializeField] float lightenAmount = 0.2f;
    [SerializeField] private Color originalLockColor;
    [SerializeField] private UnityEvent OnInteracted;
    private Color originalUnlockColor;
    private Color highlightColor;
    private Renderer objectRenderer;
    private bool isUnlocked = false;
    private void Awake() 
    {
        objectRenderer = GetComponent<Renderer>();
        originalUnlockColor = objectRenderer.material.color;
        highlightColor = originalUnlockColor + 
            new Color(lightenAmount, lightenAmount, lightenAmount);
        objectRenderer.material.color = originalLockColor;
    }
    public void OnHoverEnter()
    {
        if(!isUnlocked) return;
        objectRenderer.material.color = highlightColor;
    }

    public void OnHoverExit()
    {
        if(!isUnlocked) return;
        objectRenderer.material.color = originalUnlockColor;
    }
    public void OnInteract(InteractModule module)
    {
        if(!isUnlocked) return;
        OnInteracted.Invoke();
    }
    public void UnlockDoor()
    {
        isUnlocked = true;
        objectRenderer.material.color = originalUnlockColor;    
    }
}
