using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PuzzlePiece : MonoBehaviour
{
    [Header("Interaction")]
    public UnityEvent OnUnlock = new UnityEvent();
    [Header("Indicator")]
    [SerializeField] protected ButtonDisplay buttonDisplay;

    protected void UnlockPuzzle()
    {
        buttonDisplay?.ChangeText("Unlocked");
        buttonDisplay?.ChangeColor(Color.green);
        OnUnlock?.Invoke();
    }
    public abstract void PuzzleReset();
}
