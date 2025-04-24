using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public int scoreX;
    public Text scoreText;
    public Text killNumText;
    
    public LocalizedString scoreString;
    public LocalizedString killNumString;

    private void Awake()
    {
        scoreString.TableEntryReference = "ScoreText";
        scoreText.text = $"{scoreString.GetLocalizedString()}"+ (PlayerPrefs.GetInt("KillNum") * scoreX).ToString();
        killNumString.TableEntryReference = "KillNumText";
        killNumText.text = $"{killNumString.GetLocalizedString()}" + PlayerPrefs.GetInt("KillNum").ToString();
        int score = PlayerPrefs.GetInt("Score");
        score += PlayerPrefs.GetInt("KillNum") * scoreX;
        PlayerPrefs.SetInt("Score",score);
    }

}
