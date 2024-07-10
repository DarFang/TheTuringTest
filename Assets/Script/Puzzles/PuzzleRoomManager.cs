using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoomManager : MonoBehaviour
{
    [SerializeField] PuzzleRoom[] rooms;
    public void OnPuzzleRoomFinish(int index)
    {
        rooms[index].ExitedAndFinishPuzzle();
        if(AllPuzzlesFinished())
        {
            GameManager.Singleton.FinishLevel();
        }
    }
    public bool AllPuzzlesFinished()
    {
        foreach (PuzzleRoom room in rooms)
        {
            if(room.gameObject.activeInHierarchy)
            {
                Debug.Log("not all puzzles finished");
               return false; 
            }
        }
        Debug.Log("finished");
        return true;
    }
}
