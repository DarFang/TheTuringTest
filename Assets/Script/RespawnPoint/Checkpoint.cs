using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Respawn respawn;
    [SerializeField] bool isFirstRespawn = false;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SetRespawn(Respawn respawn)
    {
        this.respawn = respawn;
        if(isFirstRespawn)
        {
            respawn.UpdateRespawn(gameObject.transform);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("CheckpointUpdated");
            respawn.UpdateRespawn(gameObject.transform);

        }    
    }
}
