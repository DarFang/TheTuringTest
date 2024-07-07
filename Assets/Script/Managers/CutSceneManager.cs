using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] CutsceneStartType startType;
    [SerializeField] private PlayableDirector director;
    void Start()
    {
        //switch
        switch (startType)
        {
            case CutsceneStartType.OnLevelStart:GameManager.Singleton.OnLevelStart.AddListener(StartCutScene);
            break;
            case CutsceneStartType.OnLevelFinish:GameManager.Singleton.OnLevelEnds.AddListener(StartEndScene);
            break;
            case CutsceneStartType.OnDeath:GameManager.Singleton.OnPlayerDied.AddListener(StartDeathScene);
            break;
            default:
            break;
        }
    }

    public void StartCutScene()
    {
        GameManager.Singleton.LockPlayerInput();
        director.Play();
    }
    public void OnStartCutSceneEnd()
    {
        GameManager.Singleton.UnlockPlayerInput();
        GameManager.Singleton.OnLevelStart.RemoveListener(StartCutScene);
    }
    public void StartEndScene()
    {
        Debug.Log("play end");
        director.Play();
    }
    public void OnEndCutSceneEnd()
    {
        GameManager.Singleton.OnLevelEnds.RemoveListener(StartEndScene);
    }
    public void StartDeathScene()
    {
        Debug.Log("play death");
        director.Play();
    }
}
public enum CutsceneStartType
{
    OnLevelStart, OnLevelFinish, OnDeath
}
