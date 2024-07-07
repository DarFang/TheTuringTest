using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PooledObject : MonoBehaviour
{
    public Rigidbody rb;
    private ObjectPool poolOwner;
    public void LinkToPool(ObjectPool owner)
    {
        poolOwner = owner;
    }
    public void ResetBackToPool()
    {
        rb.velocity = Vector3.zero;
        poolOwner.ResetObject(this);
    }
    public void ResetBackToPool(float time)
    {
        Invoke("ResetBackToPool", time);
    }
}
