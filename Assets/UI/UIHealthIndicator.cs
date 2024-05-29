using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIHealthIndicator : MonoBehaviour
{
    public TextMeshProUGUI textHealth;

    private void Start() 
    {
        FindObjectOfType<HealthModule>().OnHealthChanged += SetHealthText;
    }
    private void Update() 
    {
        
    }
    public void SetHealthText(float healthValue)
    {
        textHealth.text = healthValue.ToString();
    }
}
