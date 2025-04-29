using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    private Animator ani;
    public AudioClip AudioClip;
    //public UnityEvent tp;
    private void Awake()
    {
        ani = GetComponent<Animator>();

    }

    public void WaitAnimator() 
    {
        
            AudioController.instance.PlaySE(AudioClip);
    }
}
