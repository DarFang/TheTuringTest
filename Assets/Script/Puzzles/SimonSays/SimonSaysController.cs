using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysController : MonoBehaviour
{
    [SerializeField] List<SimonSaysButton> buttons;
    // Start is called before the first frame update
    int currentIteration;
    int currentRound;
    int[] Sequence = {0,1,2,3};
    void Start()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetReturnValue(i, this);
        }
        StartCoroutine(PlaySequence());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PuzzleReset()
    {

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
        Debug.Log(value);
        Debug.Log(Sequence[currentIteration]);
        if(Sequence[currentIteration] == value)
        {
            if(currentIteration == currentRound)
            {
                // play next sequence
                currentIteration = 0;
                currentRound ++;
                if(currentRound == Sequence.Length)
                {
                    Debug.Log("youwin");
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
            currentIteration = 0;
            currentRound = 0;
            StartCoroutine(PlaySequence());
            Debug.Log("youlose");
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
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < currentRound+1; i++)
        {
            //play sound
            Debug.Log("number:" + Sequence[i]);
            buttons[Sequence[i]].DisplayLightup();
            yield return new WaitForSeconds(1f);
        }
    }
}
