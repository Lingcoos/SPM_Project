using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMapController : MonoBehaviour
{
    public Text scoreText;


    private void Update()
    {
        scoreText.text = PlayerData.getInstance().Score.ToString();
        Debug.Log("¼¼ÄÜ1: " + PlayerPrefs.GetInt("Skill1"));
    }

}
