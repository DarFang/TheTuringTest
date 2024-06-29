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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
