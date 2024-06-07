using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private InputController player;
    public UnityEvent OnLevelStart = new UnityEvent();
    public UnityEvent OnAction = new UnityEvent();
    public UnityEvent OnLevelEnds = new UnityEvent();
    public static GameManager Singleton{ get; private set; }
    private void Awake() {
        if(Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Invoke("StartLevel", Time.deltaTime);
    }
    public void StartLevel()
    {
        player = FindObjectOfType<InputController>();
        //start cutscene
        // start countdown
        OnLevelStart?.Invoke();
    }
    public void FinishLevel()
    {
        OnLevelEnds?.Invoke();
    }
    public void PlayerDied()
    {

    }
    public void LockPlayerInput()
    {
        Debug.Log("dsaf");
        player.enabled = false;
    }
    public void UnlockPlayerInput()
    {
        player.enabled = true;
    }
}
