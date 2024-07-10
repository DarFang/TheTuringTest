using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class CommandInteractor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [Header("Interactions")]
    [SerializeField] Camera cam;
    [SerializeField] LayerMask clickableLayer;
    [SerializeField] private Queue<Command> commands = new Queue<Command>(); 
    private Command currentCommand;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(currentCommand != null)
        {
            currentCommand.Execute();
            if(currentCommand.IsCompleted())
            {
               currentCommand = null;
            }
        }
        else if(commands.Count != 0)
        {
            currentCommand = commands.Dequeue();
            Debug.Log("Queue count" + commands.Count);
        }
    }
    public void CreateCommand()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,5f, clickableLayer))
        {
            commands.Enqueue(new MoveCommand(agent, hit.point));
        }
    }
}
