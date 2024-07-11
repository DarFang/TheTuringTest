using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    private void Start() {
        startingPosition = transform.position;
    }
    private void Update() {
        if(period <= Mathf.Epsilon){return;}
        const float tau = Mathf.PI * 2;
        float cycles = Time.time/period;
        float rawSinWav = Mathf.Sin(tau*cycles) ;
        movementFactor = (rawSinWav + 1f)/2;

        Vector3 offset = movementVector*movementFactor;
        transform.position = startingPosition + offset;
    }
}
