using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Teleport(string name) 
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1.0f;
    }
}
