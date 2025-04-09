using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Teleport(string name) 
    {
        // load the scene
        SceneManager.LoadScene(name);
        Time.timeScale = 1.0f;

    }
    public void WaitForAniFinished(string ani)
    {
        Animator animator = GameObject.Find(ani).GetComponent<Animator>();
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // wait for the animation to finish
        while (stateInfo.normalizedTime < 1.0f)
        {
            stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1.0f)
            {
                Teleport("level1");
                break;
            }
        }
    }
}
