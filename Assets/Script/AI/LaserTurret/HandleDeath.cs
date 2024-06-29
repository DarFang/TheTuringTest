using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    public GameObject playerInput;
    [SerializeField] Transform respawnPoint;
    public void OnDeath()
    {
        playerInput.gameObject.SetActive(false);
         Respawn();
    }
    public void Respawn()
    {
        playerInput.transform.position = respawnPoint.position;
        playerInput.transform.rotation = respawnPoint.rotation;
        playerInput.gameObject.SetActive(true);
    }

}
