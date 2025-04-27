using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : MonoBehaviour
{
    private Animator ani;
    public AudioClip AudioClip;
    public UnityEvent tp;
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        
    }

    public void WaitAnimator() 
    {
            AudioController.instance.PlaySE(AudioClip);
    }
}
