using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromParent : MonoBehaviour
{
    private void Start() 
    {
        transform.parent = null;
    }
}
