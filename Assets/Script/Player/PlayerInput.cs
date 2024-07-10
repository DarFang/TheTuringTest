using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speedMultiplier = 1.5f; 
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private float MaxFallSpeed = -10f;
    [SerializeField] private LayerMask floorLayer;
    [SerializeField] private float speed = 2f; 
    [SerializeField] private float MouseSensitivity = 50f;
    [SerializeField] Vector3 velocity;
    [SerializeField] Camera cam;
    CharacterController controller;
    private Vector2 aimDirection; 
    private Vector2 moveDirection;
    const float gravityAcceleration = -9.81f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void Update()
    {
        MovePlayer();
        RotatePlayer();
        Jump();
        ApplyGravity();
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            velocity.y = JumpForce;
        }
    }
    void ApplyGravity()
    {
        if(!IsGrounded()){
            velocity.y += gravityAcceleration *  Time.deltaTime;
            if(velocity.y <MaxFallSpeed){
                velocity.y = MaxFallSpeed;
            }
        }
        else if (velocity.y <0)
        {
            velocity.y = 0;
        }
        controller.Move(velocity*Time.deltaTime);
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
        aimDirection.y += -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * MouseSensitivity;
        // Rotate player up down
        aimDirection.y = Mathf.Clamp(aimDirection.y, -85f, 85f);
        cam.transform.localEulerAngles = new Vector3(aimDirection.y, 0, 0);
        //Rotate player on left right
        transform.Rotate(Vector3.up, aimDirection.x * Time.deltaTime * MouseSensitivity);
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.3f, floorLayer);
    }
}

