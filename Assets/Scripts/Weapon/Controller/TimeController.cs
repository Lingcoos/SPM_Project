using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public TMP_Text text;
    private float startTime;
    public float runTime;
    void Start()
    {
        startTime = Time.time;
    }
    private void Update()
    {
        runTime = Time.time - startTime; // ���㵱ʱ��Ϸʱ��
        string minutes = ((int)runTime / 60).ToString("00");
        string seconds = (runTime % 60).ToString("00");
        text.text = "Time: " + minutes + " : " + seconds;
    }
}
