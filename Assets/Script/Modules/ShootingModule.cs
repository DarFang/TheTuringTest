using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModule : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [Header("Shooting")]
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] Camera cam;
    public void Shoot()
    {
        PooledObject tempPooled = objectPool.RetriveAvailableItem();
        Rigidbody bulletInstantiated = tempPooled.rb;//Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
        bulletInstantiated.position = shootingPoint.position;
        bulletInstantiated.rotation = shootingPoint.rotation;
        bulletInstantiated.AddForce(1f*cam.transform.forward, ForceMode.Impulse);
        tempPooled.ResetBackToPool(5f);
    }
}
