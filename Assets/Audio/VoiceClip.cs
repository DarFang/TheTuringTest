using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceClip : MonoBehaviour
{
    
    public static VoiceClip Instance;
    [SerializeField] AudioClip[] VoiceClips;
    [SerializeField] bool isDebugging = false;
    AudioSource audioSource;

    private void Awake()
    {
        //Singleton
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayVoice(int index = 0)
    {
        if(!isDebugging)
        {
            PlaySound(index);
        }
    }
    private void PlaySound(int index)
    {
        audioSource.Stop();
        audioSource.clip = VoiceClips[index];
        audioSource.Play();
    }
}
