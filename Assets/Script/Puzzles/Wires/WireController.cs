using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WireController : MonoBehaviour
{
    [Header("Interactions")]
    public UnityEvent OnUnlock = new UnityEvent();
    [SerializeField] List<EndWireNode> endWires= new List<EndWireNode>();
    [SerializeField] List<StartWireNode> startWires= new List<StartWireNode>();
    [SerializeField] ButtonDisplay buttonDisplay;
    List<WireNode> correctWireSequence = new List<WireNode>();
    WireNode currentWireNode = null;
    SeeingModule module;
    
    void Start()
    {
        Initialise();
        RandomizeWires();

    }

    private void Initialise()
    {
        foreach (WireNode wire in endWires)
        {
            wire.LinkToController(this);
        }
        foreach (WireNode wire in startWires)
        {
            wire.LinkToController(this);
        }
    }

    public void RandomizeWires()
    {
        correctWireSequence = new List<WireNode>();
        List<WireNode> tempEndWires = new List<WireNode>(endWires);
        while(tempEndWires.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, tempEndWires.Count);
            correctWireSequence.Add(tempEndWires[randomIndex]);
            tempEndWires.RemoveAt(randomIndex);
        }
        for (int i = 0; i < correctWireSequence.Count; i++)
        {
            correctWireSequence[i].ChangeColor(startWires[i].color);
        }  
    }

    void Update()
    {
        if(currentWireNode != null)
        {
            currentWireNode.UpdateLineRender(false, module.Seeing);
        }
    }
    public bool CheckCorrectWireSequence()
    {
        for (int i = 0; i < correctWireSequence.Count; i++)
        {
            if(correctWireSequence[i] != startWires[i].connectedTo)
            {
                return false;
            }
        }
        buttonDisplay?.ChangeText("Unlocked");
        buttonDisplay?.ChangeColor(Color.green);
        OnUnlock?.Invoke();
        return true;
    }
    public void OnWireInteract(WireNode selectedWireNode, SeeingModule module)
    {
        if(currentWireNode == null)
        {
            this.module = module;
            currentWireNode = selectedWireNode;
            if(currentWireNode.connectedTo != null)
            {
                currentWireNode.Disconnect();
            }
        }
        else
        {
            if(currentWireNode != selectedWireNode)
            {
                currentWireNode.Connect(selectedWireNode);
                this.module = null;
                currentWireNode = null;
            }
            else
            {
                selectedWireNode.DisconnectLineRenderer();
                this.module = null;
                currentWireNode = null;
            }
            CheckCorrectWireSequence();           
        }
    }

}
