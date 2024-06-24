using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnInteracted;
    [SerializeField] float lightenAmount = 0.2f;
    private Color originalColor;
    private Color highlightColor;
    private Renderer objectRenderer;
    private void Awake() 
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        highlightColor = originalColor + 
            new Color(lightenAmount, lightenAmount, lightenAmount);
    }
    public void OnHoverEnter()
    {
        objectRenderer.material.color = highlightColor;
    }

    public void OnHoverExit()
    {
        objectRenderer.material.color = originalColor;
    }

    public void OnInteract(InteractModule module)
    {
        OnInteracted.Invoke();
        SoundManager.Instance.PlayButtonSound(transform.position);
    }

}
