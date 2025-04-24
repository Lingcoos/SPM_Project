using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    public static StartGameController instance;
    public string startGameTarget;

    private void Awake()
    {
        instance = this;
    }
    public void Tp() 
    {
        if (startGameTarget == null) return;
        SceneManager.LoadScene(startGameTarget);
    }
}
