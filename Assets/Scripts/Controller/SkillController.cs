using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    public static SkillController Instance;
    [Header("磁铁")]
    public float magenetCD;
    public GameObject magnet;
    public Image magnetImage;
    public bool isMagnetCD;
    public UnityEvent pickUpAll;
    public Sprite magnetKeyUi;
    public Sprite magnetControUi;
    public Image magnetImageButton;

    [Header("狂怒")]
    public float rageCD;
    public float rageDutation;
    public GameObject rage;
    public Image rageImage;
    public bool isRageCD;
    public Sprite rageKeyUi;
    public Sprite rageControUi;
    public Image rageImageButton;

    [Header("次元斩")]
    public float dsCD;
    public Transform position;
    public GameObject ds;
    public GameObject uiFilter;
    public GameObject particle;
    public Image dsImage;
    public bool isDSCD;
    public Sprite dsKeyUi;
    public Sprite dsControUi;
    public Image dsImageButton;

    private float currentTime;
    private void OnEnable()
    {
        //Debug.Log("1: " + PlayerPrefs.GetInt("Skill1") + " 2: " + PlayerPrefs.GetInt("Skill2") + " 3: "+ PlayerPrefs.GetInt("Skill3"));
        if (PlayerPrefs.GetInt("Skill2") == 1)
            rage.SetActive(true);
        else
            rage.SetActive(false);
        if (PlayerPrefs.GetInt("Skill1") == 1)
            magnet.SetActive(true);
        else
            magnet.SetActive(false);

        if (PlayerPrefs.GetInt("Skill3") == 1)
            ds.SetActive(true);
        else
            ds.SetActive(false);
    }
    private void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        UIChange();
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
    public void OnSkill3() 
    {
        if (PlayerPrefs.GetInt("Skill3") == 1 && !isDSCD)
        {

            Debug.Log("发动技能3 ");
            uiFilter.SetActive(true);
            Instantiate(particle,position.position,Quaternion.identity);
            DSCD(dsCD);
            isDSCD = true;

        }
    }

    public void RestoreFilter()
    {
        uiFilter.SetActive(false);
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
    public void DSCD(float duration)
    {

        float totalTime = duration;
        DOTween.To(
            () => duration,
            value =>
            {
                dsImage.fillAmount = value / totalTime;
            },
            0,
            duration
        )
        .OnComplete(() =>
        {
            if (dsImage.fillAmount == 0)
                isDSCD = false;
            Debug.Log("冷却完毕");
        });
    }
    public void UIChange() 
    {
        bool isGamepad = InputController.instance.GetActiveInputDevice() is Gamepad;
        bool isKey = InputController.instance.GetActiveInputDevice() is Keyboard;
        if (isGamepad) 
        {
            //Debug.Log("Gamepad");
            magnetImageButton.sprite = magnetControUi;
            rageImageButton.sprite = rageControUi;
            dsImageButton.sprite = dsControUi;

        }
        if (isKey) 
        {
            //Debug.Log("Key");
            magnetImageButton.sprite = magnetKeyUi;
            rageImageButton.sprite = rageKeyUi;
            dsImageButton.sprite = dsKeyUi;
        }
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
