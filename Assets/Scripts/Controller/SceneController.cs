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
}
