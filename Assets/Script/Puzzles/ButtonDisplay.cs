using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonDisplay : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnInteracted;
    [SerializeField] private TextMeshProUGUI text;
    public void OnHoverEnter()
    {

    }

    public void OnHoverExit()
    {

    }

    public void OnInteract(InteractModule module)
    {
        OnInteracted?.Invoke();
        SoundManager.Instance.PlayButtonSound(transform.position);
    }

    public void ChangeText(String text)
    {
        this.text.text = text;
    }
    public void ChangeColor(Color color)
    {
        this.text.color = color;
    }

}
