using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script should only get input from thje input Class

public class InputController : MonoBehaviour
{
     [SerializeField] private Camera camera;
    [SerializeField] private float mouseSensitivity = 50f;
    [Header("Modules")]
    [SerializeField] private ShootingModule shootingModule;
    [SerializeField] private MovementModule movementModule;
    [SerializeField] private JumpModule jumpModule;
    [SerializeField] private InteractModule interactModule;
    // Start is called before the first frame update
    Vector3 moveDirection = Vector2.zero;
    Vector2 aimDirection = Vector2.zero;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        aimDirection.x = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        aimDirection.y = -Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        if(shootingModule != null && Input.GetMouseButtonDown(0))
        {
            shootingModule.Shoot();
        }
        if(interactModule != null && Input.GetKeyDown(KeyCode.E))
        {
            interactModule.InteractWithObject();
        }
        if(movementModule != null)
        {
            movementModule.MoveCharacter(moveDirection);
            movementModule.RotateCharacter(aimDirection);
        }

        if(jumpModule != null && Input.GetKeyDown(KeyCode.Space))
        {
            jumpModule.Jump();
        }
    }
}
