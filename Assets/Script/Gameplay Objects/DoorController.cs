using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void OpenDoor()
    {
        animator.SetBool("DoorOpen", true);
        SoundManager.Instance.PlayDoorSound(transform.position);
    }
    public void CloseDoor()
    {
        animator.SetBool("DoorOpen", false);
        SoundManager.Instance.PlayDoorSound(transform.position);
    }
    private void OnTriggerEnter(Collider other) 
    {
        // animator.SetBool("DoorOpen", true);
    }
    private void OnTriggerExit(Collider other) 
    {
        // animator.SetBool("DoorOpen", false);
    }
}
