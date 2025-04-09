using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : MonoBehaviour
{
    private Animator ani;
    public string aniName;
    public UnityEvent tp;
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        WaitAnimator(aniName);
    }

    public void WaitAnimator(string name) 
    {
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        if (info.IsName(name)&& info.normalizedTime >= 0.5f) 
        {
            tp.Invoke();
            Debug.Log("¶¯»­Íê³É");
        }
    }
}
