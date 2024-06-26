using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SimonSaysController : MonoBehaviour
{
    [SerializeField] List<SimonSaysButton> buttons;
    // Start is called before the first frame update
    int currentIteration;
    int currentRound;
    int[] Sequence = {0,1,2,3};
    bool idleState = true;
    public UnityEvent OnUnlock = new UnityEvent();
    [SerializeField] ButtonDisplay buttonDisplay;
    void Awake()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetReturnValue(i, this);
        }
        StartCoroutine(IdleCoroutine());
    }

    void Update()
    {
        
    }
    public void PuzzleReset()
    {
        idleState = false;
        currentIteration = 0;
        currentRound = 0;
        GeneratePuzzleSeqence(4);
        UnLightUpAllButtons();
        StartCoroutine(PlaySequence());
    }
    public void GeneratePuzzleSeqence(int iterations)
    {
        currentIteration = 0;
        currentRound = 0;
        Sequence = new int[iterations];
        for (int i = 0; i < iterations; i++)
        {
            Sequence[i] = Random.Range(0, buttons.Count);
        }
    }
    public void OnButtonPressed(int value)
    {
        if(Sequence[currentIteration] == value)
        {
            if(currentIteration == currentRound)
            {
                // play next sequence
                currentIteration = 0;
                currentRound ++;
                if(currentRound == Sequence.Length)
                {
                    LightUpAllButtons();
                    idleState = true;
                    StartCoroutine(IdleCoroutine());
                    buttonDisplay?.ChangeText("Unlocked");
                    buttonDisplay?.ChangeColor(Color.green);
                    OnUnlock?.Invoke();
                }
                else
                {
                    StartCoroutine(PlaySequence());
                }
            }
            else
            {
                currentIteration ++;
            }
        }
        else
        {
            PuzzleReset();
        }
    }
    public void DisableButtonInput()
    {
        buttonDisplay?.ChangeText("Listen");
        foreach (SimonSaysButton button in buttons)
        {
            button.Disable();
        }
    }
    public void EnableButtonInput()
    {
        buttonDisplay?.ChangeText("Your Turn");
        foreach (SimonSaysButton button in buttons)
        {
            button.Enable();
        }
    }
    IEnumerator PlaySequence()
    {
        DisableButtonInput();
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < currentRound+1; i++)
        {
            //play sound
            buttons[Sequence[i]].ButtonBlink();
            yield return new WaitForSeconds(1f);
        }
        EnableButtonInput();
    }
    public void UnLightUpAllButtons()
    {
        foreach (SimonSaysButton button in buttons)
        {
            button.UnlightUpColor();
        }
    }
    
    public void LightUpAllButtons()
    {
        foreach (SimonSaysButton button in buttons)
        {
            button.LightUpColor();
        }
    }
    public void RandomiseLightupButtons()
    {
        foreach (SimonSaysButton button in buttons)
        {
            if(Random.Range(0, 2) == 0)
            {
                button.LightUpColor();
            } 
            else{
                button.UnlightUpColor();
            }    
        }
    }
    IEnumerator IdleCoroutine()
    {
        yield return new WaitForSeconds(1);
        while (idleState)
        {
            RandomiseLightupButtons();
            yield return new WaitForSeconds(1);
        }
    }
}
