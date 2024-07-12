using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightsOutController : PuzzlePiece
{

    [Header("Button Settings")]
    [SerializeField] Vector2Int size;
    [SerializeField] float offSet = .1f;
    [SerializeField] Transform StartPosition;
    [SerializeField] LightsOutButton lightsOutButton;
    Dictionary<Vector2Int, LightsOutButton> buttons = new Dictionary<Vector2Int, LightsOutButton>();
    Vector2Int[] AdjacentTiles = {Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right}; 
    void Start()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                LightsOutButton buttonInstance = Instantiate(lightsOutButton, StartPosition);
                buttonInstance.transform.localPosition = new Vector3(x*offSet,0 , y*offSet);
                Vector2Int pos = new Vector2Int(x, y);
                buttonInstance.SetPosition(pos, this);
                buttons.Add(pos, buttonInstance);
            }
        }
        PuzzleReset();
        buttonDisplay?.ChangeColor(Color.red);
        buttonDisplay?.ChangeText("Locked");
    }
    void Update()
    {
        
    }
    public override void PuzzleReset()
    {
        // Randomise buttons
        foreach (KeyValuePair<Vector2Int, LightsOutButton> button in buttons)
        {
            button.Value.SetButtonValue(Random.Range(0, 2) == 0);
        }
    }

    public void toggleAdjacentValues(Vector2Int currentPos)
    {
        foreach (Vector2Int offset in AdjacentTiles)
        {
            if(buttons.TryGetValue(offset+currentPos, out LightsOutButton neighbor))
            {
                neighbor.FlipLight();
            }
        }
        CheckAnswer();
    }
    public bool CheckAnswer()
    {
        foreach (KeyValuePair<Vector2Int, LightsOutButton> button in buttons)
        {
            if(button.Value.Value == true) return false;
        }
        UnlockPuzzle();
        return true;
    }
}
