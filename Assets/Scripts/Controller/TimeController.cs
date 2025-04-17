using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Text text;
    private float startTime;
    public float runTime;
    public LocalizedString nameString;
    void Start()
    {
        startTime = Time.time;
        nameString.TableEntryReference = "TimeText";
    }
    private void Update()
    {
        runTime = Time.time - startTime; // ���㵱ʱ��Ϸʱ��
        string minutes = ((int)runTime / 60).ToString("00");
        string seconds = (runTime % 60).ToString("00");
        text.text =$"{nameString.GetLocalizedString()} : " + minutes + " : " + seconds;
    }
}
