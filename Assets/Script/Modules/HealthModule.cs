using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HealthModule : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    public Action<float> OnHealthChanged; 
    public UnityEvent OnDie; 
    private float currentHealth;
    void Start()
    {
        currentHealth = _maxHealth;
    }
    public void DeductHealth(float toDeduct)
    {
        currentHealth -= toDeduct;
        OnHealthChanged?.Invoke(currentHealth);
        if(currentHealth <=0)
        {
            currentHealth = _maxHealth;
            OnDie?.Invoke();
        }
    }
}
