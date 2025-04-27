using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource BGMScoure;
    public AudioSource SESource;
    private void Awake()
    {
        instance = this;
    }

    public void PlaySE(AudioClip audio) 
    {
        SESource.clip = audio;
        SESource.Play();
    }
}
