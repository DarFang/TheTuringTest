using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysController : MonoBehaviour
{
    [SerializeField] List<SimonSaysButton> buttons;
    // Start is called before the first frame update
    int currentIteration;
    int currentRound;
    int[] Sequence = {0,1,2,3};
    bool idleState = true;
    void Awake()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetReturnValue(i, this);
        }
        StartCoroutine(IdleCoroutine());
    }

    // Update is called once per frame
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
        Debug.Log("input value: "+ value);
        Debug.Log("correct value: "+Sequence[currentIteration]);
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
                }
                else
                {
                    Debug.Log("finishedround");
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
            Debug.Log("youlose");
            PuzzleReset();
        }
    }
    public void DisableButtonInput()
    {
        foreach (SimonSaysButton button in buttons)
        {
            button.Disable();
        }
    }
    public void EnableButtonInput()
    {
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
            Debug.Log("number:" + Sequence[i]);
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
