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
        GameManager.Singleton.OnLevelStart.AddListener(StartCutScene);
    }

    public void StartCutScene()
    {
        GameManager.Singleton.LockPlayerInput();
        director.Play();
    }
    public void OnCutSceneEnd()
    {
        GameManager.Singleton.UnlockPlayerInput();
        GameManager.Singleton.OnLevelStart.RemoveListener(StartCutScene);
        Destroy(gameObject);
    }
}
public enum CutsceneStartType
{
    OnLevelStart, OnLevelFinish
}
