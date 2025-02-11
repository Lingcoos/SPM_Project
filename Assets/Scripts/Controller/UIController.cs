using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Exp")]
    public Slider expSlider;
    public Text expText;



    public void UpdateExp(int currtExp,int levelExp,int currtLevel)
    {
        expSlider.maxValue = levelExp;
        expSlider.value = currtExp;      
        expText.text = "Level: "+ currtLevel.ToString();
    }
}
