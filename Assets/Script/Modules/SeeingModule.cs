using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeingModule : MonoBehaviour
{
    public Vector3 Seeing {get; private set;} 
    [SerializeField] Camera cam;
    [SerializeField] private LayerMask seeingLayer;
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 4f, seeingLayer ))
        {
            Seeing = hit.point;
        }
    }
}
