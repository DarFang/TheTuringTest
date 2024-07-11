using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] int Damage = 1; 
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            HealthModule health = other.gameObject.GetComponent<HealthModule>();
            if(health != null)
            {
                health.DeductHealth(Damage);
            }
        }
    }

}
