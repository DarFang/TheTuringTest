using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeingModule : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] private LayerMask seeingLayer;
    public Vector3 Seeing {get; private set;} 
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 4f, seeingLayer ))
        {
            Seeing = hit.point;
        }
    }
}
