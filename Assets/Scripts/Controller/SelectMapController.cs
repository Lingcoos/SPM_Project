using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class SelectMapController : MonoBehaviour
{
    public Text scoreText;
    public LocalizedString nameString;


    private void Start()
    {
        nameString.TableEntryReference = "ScoreText";
        //PlayerData.getInstance().InitData();
    }
    private void Update()
    {
        scoreText.text = $"{nameString.GetLocalizedString()}" + PlayerPrefs.GetInt("Score").ToString();

        //Debug.Log($"{nameString.GetLocalizedString()}" + PlayerPrefs.GetInt("Score"));
    }

}
