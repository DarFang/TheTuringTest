using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Checkpoint[] checkpoints;
    [SerializeField] Transform currentRespawn;

    public static Respawn Singleton { get; private set;}
     private void Awake() {
        if(Singleton == null)
        {
            Singleton = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            GetCheckpoints();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GetCheckpoints()
    {
         checkpoints = FindObjectsOfType<Checkpoint>();
         foreach (var item in checkpoints)
         {
            item.SetRespawn(this);
         }
    }
    public void UpdateRespawn(Transform respawn)
    {
        currentRespawn = respawn;
    }
    public Transform GetRespawn()
    {
        return currentRespawn;
    }
}
