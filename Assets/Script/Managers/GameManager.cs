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
    public UnityEvent OnPlayerDied = new UnityEvent();
    public static GameManager Singleton{ get; private set; }
    private void Awake() {
        if(Singleton == null)
        {
            Singleton = this;
            transform.parent = null;
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
        OnLevelStart?.Invoke();
    }
    public void FinishLevel()
    {
        Debug.Log("game manager finish");
        OnLevelEnds?.Invoke();
    }
    public void PlayerDied()
    {
        OnPlayerDied?.Invoke();
    }
    public void LockPlayerInput()
    {
        player.enabled = false;
    }
    public void UnlockPlayerInput()
    {
        player.enabled = true;
    }
}
