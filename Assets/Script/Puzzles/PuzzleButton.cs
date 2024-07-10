using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleButton : MonoBehaviour, IInteractable
{
    [Header("Interaction")]
    [SerializeField] protected UnityEvent OnInteracted;
    
    [Header("Indicator")]
    protected Color defaultColor;
    [SerializeField] protected Color highlightColor;
    protected Renderer objectRenderer;
    [SerializeField] protected float lightenAmount = 0.2f;
    protected bool canInteract = true;

    protected virtual void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
        defaultColor = objectRenderer.material.color;
    }

    public virtual void OnHoverEnter()
    {
        objectRenderer.material.color += new Color(1, 1, 1) * lightenAmount;
        defaultColor += new Color(1, 1, 1) * lightenAmount;
        highlightColor += new Color(1, 1, 1) * lightenAmount;
    }

    public virtual void OnHoverExit()
    {
        objectRenderer.material.color -= new Color(1, 1, 1) * lightenAmount;
        defaultColor -= new Color(1, 1, 1) * lightenAmount;
        highlightColor -= new Color(1, 1, 1) * lightenAmount;
    }

    public virtual void OnInteract(InteractModule module)
    {
        if (!canInteract) return;
        // Add common interaction logic here if any
    }

    public virtual void Disable()
    {
        canInteract = false;
    }

    public virtual void Enable()
    {
        canInteract = true;
    }

    public virtual void ButtonBlink()
    {
        StartCoroutine(BlinkButtonCoroutine());
    }

    protected virtual IEnumerator BlinkButtonCoroutine()
    {
        objectRenderer.material.color = highlightColor;
        yield return new WaitForSeconds(1);
        objectRenderer.material.color = defaultColor;
    }
}