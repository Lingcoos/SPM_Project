using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Exp")]
    public Slider expSlider;
    public Text expText;
    [Header("Hp")]
    public Image hpMaskimage;
    private float originalSize;
    [Header("Esc Panel")]
    public GameObject escPanel;
    [Header("Kill Number")]
    public Text killNumber;



    private bool isEsc;
    private void Awake()
    {       
        originalSize = hpMaskimage.rectTransform.rect.width;
    }

    public void OnEsc()
    {
        escPanel.SetActive(!escPanel.activeSelf);
        if (escPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1f;
        }
    }
    private void Update()
    {
        SetHPValue(PlayerData.getInstance().CurrentHealth / PlayerData.getInstance().CurrentMaxHealth);
        setKillNumber();
    }

    public void UpdateExp(int currtExp,int levelExp,int currtLevel)
    {
        expSlider.maxValue = levelExp;
        expSlider.value = currtExp;      
        expText.text = "Level: "+ currtLevel.ToString();
    }
    public void SetHPValue(float fillPercent)
    {
        hpMaskimage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fillPercent * originalSize);
    }
    public void setKillNumber() 
    {
        killNumber.text = "Kill Number " + PlayerData.getInstance().KillNum.ToString();
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
}
