using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void OnTriggerEnter(Collider other) {
        animator.SetBool("DoorOpen", true);
    }
    private void OnTriggerExit(Collider other) {
        animator.SetBool("DoorOpen", false);
    }
}
