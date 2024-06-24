using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWireNode : WireNode
{
    [SerializeField] public Color color = Color.white;
    private void Start() 
    {
        ChangeColor(color);
    }
}
