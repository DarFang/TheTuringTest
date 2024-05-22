using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingModule : MonoBehaviour
{
    [Header("Aiming")]
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] Camera camera;
    public void Shoot()
    {
        Rigidbody bulletInstantiated = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
        bulletInstantiated.AddForce(1f*camera.transform.forward, ForceMode.Impulse);
        Destroy(bulletInstantiated.gameObject, 5f);

    }
}
