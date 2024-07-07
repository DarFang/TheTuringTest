using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    [SerializeField] GameObject playerInput;
    [SerializeField] GameObject timeline;
    [SerializeField] Transform respawnPoint;
    public void OnDeath()
    {
        timeline.transform.parent = null;
        playerInput.gameObject.SetActive(false);
        GameManager.Singleton.PlayerDied();
    }
    public void Respawn()
    {
        playerInput.transform.position = respawnPoint.position;
        playerInput.transform.rotation = respawnPoint.rotation;
        playerInput.gameObject.SetActive(true);
        ReattachTimelineToPlayer();
    }

    private void ReattachTimelineToPlayer()
    {
        timeline.transform.parent = playerInput.transform;
        timeline.transform.localPosition = Vector3.zero;
    }
}
