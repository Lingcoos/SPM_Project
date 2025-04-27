using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [Header("磁铁")]
    public float magenetCD;
    public GameObject magnet;
    public Image magnetImage;
    public bool isMagnetCD;
    public UnityEvent pickUpAll;

    [Header("狂怒")]
    public float rageCD;
    public float rageDutation;
    public GameObject rage;
    public Image rageImage;
    public bool isRageCD;
    

    private float currentTime;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("Skill1") == 1)
            magnet.SetActive(true);
        else
            magnet.SetActive(false);
        if (PlayerPrefs.GetInt("Skill2") == 1)
            rage.SetActive(true);
        else
            rage.SetActive(false);
    }
    public void OnSkill1()
    {
        if (PlayerPrefs.GetInt("Skill1") == 1 && !isMagnetCD)
        {
            pickUpAll.Invoke();
            Debug.Log("发动技能1");
            isMagnetCD = true;
            MagnetCD(magenetCD);
        }
    }
    public void OnSkill2() 
    {
        if (PlayerPrefs.GetInt("Skill2") == 1 && !isRageCD)
        {
            PlayerData.getInstance().ExtraDamge = 20;
            Debug.Log("发动技能2 " + PlayerData.getInstance().ExtraDamge);
            ImproveAttackDuration(rageDutation);
            isRageCD = true;
            
        }
    }
    public void ImproveAttackDuration(float duration) 
    {
        rageImage.fillAmount = 1;
        DOTween.To(() => currentTime,
            time =>
            {
                currentTime = time;
            },
            0,
            duration
            )
        .OnComplete(() => 
            {
                PlayerData.getInstance().ExtraDamge =0 ;
                Debug.Log("攻击力加成结束 "+ PlayerData.getInstance().ExtraDamge);
                RageCD(rageCD);
                
            });
    }
    public void RageCD(float duration)
    {
        
        float totalTime = duration;
        DOTween.To(
            () => duration,
            value =>
            {
                rageImage.fillAmount = value / totalTime;
            },
            0,
            duration
        )
        .OnComplete(() =>
        {
            if (rageImage.fillAmount == 0)
                isRageCD = false;
            Debug.Log("冷却完毕");
        });
    }

    public void MagnetCD(float duration)
    {
        magnetImage.fillAmount = 1;
        float totalTime = duration;
        DOTween.To(
            () => duration,
            value =>
            {
                magnetImage.fillAmount = value / totalTime;
            },
            0,
            duration
        )
        .OnComplete(() => 
            {
                if (magnetImage.fillAmount == 0)
                    isMagnetCD = false;
                Debug.Log("冷却完毕");
            });
    }


}
