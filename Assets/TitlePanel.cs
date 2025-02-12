using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadScene("level0");
    }

    void SettingGame()
    {

    }

    void EndGame()
    {
        // Save Game
        PlayerData.getInstance().SaveAllData();
        // Quit Game
        //Application.quit();
    }


}
