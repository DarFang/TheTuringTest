using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireNode : MonoBehaviour, IInteractable
{
    public WireNode connectedTo {get; private set;} = null;
    [Header("Indicator")]
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Renderer renderer;
    [SerializeField] Vector3 offset = Vector3.zero;
    WireController controller;
    public void OnHoverEnter()
    {
        
    }

    public void OnHoverExit()
    {
        
    }

    public void OnInteract(InteractModule module)
    {
        controller.OnWireInteract(this, module.gameObject.GetComponent<SeeingModule>());
    }

    public void LinkToController(WireController wireController)
    {
        controller = wireController;
    }

    public void UpdateLineRender(bool disconnect, Vector3 endPos)
    {
        if(disconnect)
        {
            lineRenderer.positionCount = 0;
        }
        else
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position + offset);
            lineRenderer.SetPosition(1, endPos);
        }
    }
    public void DisconnectLineRenderer()
    {
        lineRenderer.positionCount = 0;
    }
    public void Connect(WireNode otherWire)
    {
        if(otherWire.connectedTo != null)
        {
            otherWire.Disconnect();
        }
        connectedTo = otherWire;
        otherWire.connectedTo = this;
    }
    public void Disconnect()
    {
        connectedTo.connectedTo = null;
        connectedTo.DisconnectLineRenderer();
        connectedTo = null;
        DisconnectLineRenderer();
    }
    public void ChangeColor(Color color)
    {
        renderer.material.color = color;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }
}
