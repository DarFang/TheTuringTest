using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightsOutButton :  MonoBehaviour, IInteractable
{
    public bool Value{get; private set;}
    LightsOutController controller;
    private Color defaultColor;
    [SerializeField] private UnityEvent OnInteracted;
    [SerializeField] private Color highlightColor;
    private Renderer objectRenderer;
    private bool canInteract = true;
    [SerializeField] float lightenAmount = 0.2f;
    Vector2Int myPosition;
    private void Awake() 
    {
        objectRenderer = GetComponent<Renderer>();
        defaultColor = objectRenderer.material.color; 
    }
    public void OnHoverEnter()
    {
        objectRenderer.material.color += new Color(1,1,1)*lightenAmount;
        defaultColor += new Color(1,1,1)*lightenAmount;
        highlightColor += new Color(1,1,1)*lightenAmount;
    }

    public void OnHoverExit()
    {
        objectRenderer.material.color -= new Color(1,1,1)*lightenAmount;
        defaultColor -= new Color(1,1,1)*lightenAmount;
        highlightColor -= new Color(1,1,1)*lightenAmount;
    }

    public void OnInteract(InteractModule module)
    {
        if(!canInteract) return;

        FlipLight();
        controller.toggleAdjacentValues(myPosition);
        
    }
    public void Disable()
    {
        canInteract = false;
    }
    public void Enable()
    {
        canInteract = true;
    }
    public void ButtonBlink()
    {
        StartCoroutine(BlinkButtonCoroutine());
    }
    private IEnumerator BlinkButtonCoroutine()
    {
        objectRenderer.material.color = highlightColor;
        yield return new WaitForSeconds(1);
        objectRenderer.material.color = defaultColor;
    }
    public void SetButtonLightStatus(bool isLight)
    {
        objectRenderer.material.color = isLight ? highlightColor : defaultColor;
    }
    public void SetButtonValue(bool value)
    {
        this.Value = value;
        SetButtonLightStatus(value);
    }
    public void FlipLight()
    {
        SetButtonValue(!Value);
    }
    public void SetPosition(Vector2Int position, LightsOutController controller)
    {
        this.controller = controller;
        myPosition = position;
    }
}
