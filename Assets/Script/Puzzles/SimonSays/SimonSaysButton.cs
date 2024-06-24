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
    [SerializeField] float lightenAmount = 0.2f;
    private void Awake() 
    {
        objectRenderer = GetComponent<Renderer>();
        defaultColor = objectRenderer.material.color; 
        LightUpColor();
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
        controller.OnButtonPressed(value);
        ButtonBlink();
        SoundManager.Instance.PlayButtonSound(transform.position);
    }

    public void SetReturnValue(int value, SimonSaysController controller)
    {
        this.controller = controller;
        this.value = value;
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
        yield return new WaitForSeconds(lightUpDuration);
        objectRenderer.material.color = defaultColor;
    }
    public void LightUpColor ()
    {
        objectRenderer.material.color = highlightColor;
    }
    public void UnlightUpColor()
    {
        objectRenderer.material.color = defaultColor;
    }

}
