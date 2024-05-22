using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script should only get input from thje input Class

public class InputController : MonoBehaviour
{
    [SerializeField] private ShootingModule shootingModule;
    //[SerializeField] private WalkingModuel WalkingModuel;
    //[SerializeField] private JumpingModule JumpingModule;
    [SerializeField] private InteractModule interactModule;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shootingModule != null && Input.GetMouseButtonDown(0))
        {
            shootingModule.Shoot();
        }
        if(interactModule != null && Input.GetKeyDown(KeyCode.E))
        {
            interactModule.InteractWithObject();
        }
    }
}
