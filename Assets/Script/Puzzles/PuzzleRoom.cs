using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoom : MonoBehaviour
{
    float timer;
    [SerializeField] private bool isCompleted;
    [SerializeField] private bool isCurrentPuzzle;
    [SerializeField] private int voiceIndex = 0;
    private void OnTriggerEnter(Collider other) 
    {
        isCurrentPuzzle = true;
    }
    private void OnTriggerExit(Collider other) 
    {
        if(isCompleted && isCurrentPuzzle)
        {
            //we can destroy stuff
        }
        isCurrentPuzzle = false;
    }
    public void ExitedAndFinishPuzzle()
    {
        VoiceClip.Instance.PlayVoice(voiceIndex);
        gameObject.SetActive(false);
    }
}
