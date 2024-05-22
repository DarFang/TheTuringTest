using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
    public void OnHoverEnter();
    public void OnHoverExit();
    public void OnInteract(InteractModule module);
} 