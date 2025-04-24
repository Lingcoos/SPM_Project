using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMapController : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        //PlayerData.getInstance().InitData();
    }
    private void Update()
    {
        scoreText.text = "Score: "+ PlayerPrefs.GetInt("Score").ToString();

        Debug.Log("ตรทึ" + PlayerPrefs.GetInt("Score"));
    }

}
