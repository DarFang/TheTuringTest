using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOutController : MonoBehaviour
{
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
                buttonInstance.transform.position = new Vector3(x*offSet,0 , y*offSet) + StartPosition.position;
                Vector2Int pos = new Vector2Int(x, y);
                buttonInstance.SetPosition(pos, this);
                buttons.Add(pos, buttonInstance);
            }
        }
        RandomiseLightupButtons();
    }
    void Update()
    {
        
    }
    public void RandomiseLightupButtons()
    {
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
        Debug.Log("solved");
        return true;
    }
}
