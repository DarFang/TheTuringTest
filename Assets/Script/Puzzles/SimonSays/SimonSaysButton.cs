using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimonSaysButton : MonoBehaviour, IInteractable
{
    private int value;
    SimonSaysController controller;
    private Color defaultColor;
    [SerializeField] private UnityEvent OnInteracted;
    [SerializeField] private Color highlightColor;
    private Renderer objectRenderer;
    [SerializeField] float lightUpDuration = 1f;
    private bool canInteract = false;
    private void Start() 
    {
        objectRenderer = GetComponent<Renderer>();
        defaultColor = objectRenderer.material.color; 
    }
    public void OnHoverEnter()
    {

    }

    public void OnHoverExit()
    {
        
    }

    public void OnInteract(InteractModule module)
    {
        controller.OnButtonPressed(value);
        StartCoroutine(LightUpColor());
    }

    public void SetReturnValue(int value, SimonSaysController controller)
    {
        this.controller = controller;
        this.value = value;
    }
    public void Disable()
    {

    }
    public void Enable()
    {
        
    }
    public void DisplayLightup()
    {
        StartCoroutine(LightUpColor());
    }
    public IEnumerator LightUpColor()
    {
        objectRenderer.material.color = highlightColor;
        yield return new WaitForSeconds(lightUpDuration);
        objectRenderer.material.color = defaultColor;
    }
}
