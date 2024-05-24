using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] Camera camera;
    [SerializeField] private float movementSpeed;
    private Vector3 moveDirection;
    private Vector2 aimDirection;

    public void MoveCharacter(Vector3 direction)
    {
        moveDirection.x = direction.x;
        moveDirection.z = direction.z;

        float tempMultiplier = 1;

        controller.Move(((transform.right * moveDirection.x) + (transform.forward * moveDirection.z)) * Time.deltaTime * movementSpeed * tempMultiplier);
    }

    public void RotateCharacter(Vector3 direction)
    {
        aimDirection.x = direction.x;
        aimDirection.y += direction.y * Time.deltaTime;

        // Rotate player up down
        aimDirection.y = Mathf.Clamp(aimDirection.y, -85f, 85f);
        camera.transform.localEulerAngles = new Vector3(aimDirection.y, 0, 0);
        //Rotate player on left right
        transform.Rotate(Vector3.up, aimDirection.x * Time.deltaTime);
    }
}
