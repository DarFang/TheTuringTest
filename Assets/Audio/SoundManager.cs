using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] AudioClip[] PickupSound;
    [SerializeField] AudioClip ButtonSound;
    [SerializeField] AudioClip DoorSound;
    [SerializeField] AudioClip TaskComplete;
    [SerializeField] AudioClip[] MusicKeys;

    private void Awake()
    {
        //Singleton
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayPickup(Vector3 pos, int index = 0)
    {
        PlaySound(PickupSound[index], pos);
    }
    public void PlayMusicKey(Vector3 pos, int index = 0)
    {
        PlaySound(MusicKeys[index], pos);
    }
    public void PlayButtonSound(Vector3 pos)
    {
        PlaySound(ButtonSound, pos);
    }
    public void PlayDoorSound(Vector3 pos)
    {
        PlaySound(DoorSound, pos);
    }
        public void PlayTaskComplete(Vector3 pos)
    {
        PlaySound(TaskComplete, pos);
    }
    private void PlaySound(AudioClip sound, Vector3 pos)
    {
        
        AudioSource.PlayClipAtPoint(sound, pos);
    }

}
