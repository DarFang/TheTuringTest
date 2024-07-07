using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoom : MonoBehaviour
{
    [SerializeField] private bool isCompleted;
    [SerializeField] private bool isCurrentPuzzle;
    [SerializeField] private int voiceIndex = 0;
    float timer;
    private void OnTriggerEnter(Collider other) 
    {
        isCurrentPuzzle = true;
    }
    private void OnTriggerExit(Collider other) 
    {
        if(isCompleted && isCurrentPuzzle)
        {
            
        }
        isCurrentPuzzle = false;
    }
    public void ExitedAndFinishPuzzle()
    {
        VoiceClip.Instance.PlayVoice(voiceIndex);
        gameObject.SetActive(false);
    }
}
