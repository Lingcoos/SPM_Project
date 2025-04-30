using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Text text;
    private float startTime;
    public float runTime;
    public float tpTime;
    public UnityEvent tpEvent;
    public LocalizedString nameString;
    void Start()
    {
        startTime = Time.time;
        nameString.TableEntryReference = "TimeText";
    }
    private void Update()
    {
        if ((int)runTime == tpTime)
        {
            //Debug.Log("生存成功");
            tpEvent.Invoke();
        }
        else 
        {
            runTime = Time.time - startTime; // 计算当时游戏时间
            string minutes = ((int)runTime / 60).ToString("00");
            string seconds = (runTime % 60).ToString("00");
            text.text = $"{nameString.GetLocalizedString()} : " + minutes + " : " + seconds;
            PlayerPrefs.SetFloat("Time", runTime);
        }
       
    }
}
