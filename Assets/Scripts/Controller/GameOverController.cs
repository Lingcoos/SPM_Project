using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{
    public int scoreX;
    public Text suriveTime;
    public Text scoreText;
    public Text killNumText;

    public LocalizedString survivalString;
    public LocalizedString scoreString;
    public LocalizedString killNumString;

    private void Awake()
    {
        float time = PlayerPrefs.GetFloat("Time");
        string minutes = ((int)time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        suriveTime.text = $"{survivalString.GetLocalizedString()}" + minutes + " : " + seconds;
        scoreString.TableEntryReference = "ScoreText";
        scoreText.text = $"{scoreString.GetLocalizedString()}"+ (PlayerPrefs.GetInt("KillNum") * scoreX).ToString();
        killNumString.TableEntryReference = "KillNumText";
        killNumText.text = $"{killNumString.GetLocalizedString()}" + PlayerPrefs.GetInt("KillNum").ToString();
        int score = PlayerPrefs.GetInt("Score");
        score += PlayerPrefs.GetInt("KillNum") * scoreX;
        PlayerPrefs.SetInt("Score",score);
    }

}
