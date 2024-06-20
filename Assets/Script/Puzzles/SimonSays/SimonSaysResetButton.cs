using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimonSaysResetButton : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent ButtonPressed;
    private Renderer objectRenderer;
    [SerializeField] float lightenAmount = 0.2f;
    Color defaultColor;
    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        defaultColor = objectRenderer.material.color; 
    }

    public void OnHoverEnter()
    {
        objectRenderer.material.color += new Color(1,1,1)*lightenAmount;
    }

    public void OnHoverExit()
    {
        objectRenderer.material.color -= new Color(1,1,1)*lightenAmount;
    }

    public void OnInteract(InteractModule module)
    {
        ButtonPressed?.Invoke();
    }
}
