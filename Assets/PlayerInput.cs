using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] Camera camera;
    [SerializeField] private float speed = 2f; 
    [SerializeField] private float speedMultiplier = 1.5f; 
    [SerializeField] private Vector2 aimDirection; 
    [SerializeField] private float MouseSensitiviy = 50f;
    CharacterController controller;
    float gravity = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void Gravity()
    {
        
    }
    void Update()
    {
        MovePlayer();
        RotatePlayer();
        //shoot
        //jump
        //check if grounded
    }
    void MovePlayer()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        float speedOutput = Input.GetKey(KeyCode.LeftShift)? speed*speedMultiplier: speed;
        // Move player
        controller.Move((transform.right* moveDirection.x + transform.forward*moveDirection.y) * Time.deltaTime * speedOutput);
    }

    private void RotatePlayer()
    {
        aimDirection.x = Input.GetAxisRaw("Mouse X");
        aimDirection.y += -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * MouseSensitiviy;

        // Rotate player up down
        aimDirection.y = Mathf.Clamp(aimDirection.y, -85f, 85f);
        camera.transform.localEulerAngles = new Vector3(aimDirection.y, 0, 0);
        //Rotate player on left right
        transform.Rotate(Vector3.up, aimDirection.x * Time.deltaTime * MouseSensitiviy);
    }
}

