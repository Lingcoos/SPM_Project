using Mirror.BouncyCastle.Crypto;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameSettingController : MonoBehaviour
{
    public static GameSettingController instance;
    [Header("����")]
    public Dropdown languageDropDown;
    
    [Header("�ֱ���")]
    public TMP_Dropdown resolutionDropDown;
    [SerializeField] private Resolution[] resolutions;

    [Header("ȫ����")]
    public Toggle fullScreenController;

    [Header("�ֱ���")]
    public Toggle controllerVibraton;
    public bool isVibration;


    [Header("��Ƶ")]
    public AudioMixer masterMixer;
    public AudioMixer musicMixer;
    public AudioMixer vfMixer;
    public Slider master;
    public Slider music;
    public Slider vf;

    private float timeDelta = 0.5f;
    private float prevTime;
    private float fps;
    private int frames;

    private GUIStyle style;
    private void Awake()
    {
        instance =this;
        Screen.fullScreen = true;
        Application.targetFrameRate = 280;
    }
    private void Start()
    {
        InitializeLanguageDropDown();
        InitialzieResolutionDropDown();
        prevTime = Time.realtimeSinceStartup;
        style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = new Color(255, 255, 255);
        statusCheck();
       
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(0, Screen.height - 40, 200, 200), "FPS: " + fps.ToString("f2"), style);
    }
    private void Update()
    {
        frames++;
        if (Time.realtimeSinceStartup >= prevTime + timeDelta) 
        {
            fps = ((float)frames / (Time.realtimeSinceStartup - prevTime));
            prevTime = Time.realtimeSinceStartup;
            frames = 0;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void InitialzieResolutionDropDown() //�ֱ��ʳ�ʼ��
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        var options = new System.Collections.Generic.List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);


            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }
    public void InitializeLanguageDropDown() //�����л���ʼ��
    {
        languageDropDown.ClearOptions();
        var locales =LocalizationSettings.AvailableLocales.Locales;
        foreach (var locale in locales) 
        {
            languageDropDown.options.Add(new Dropdown.OptionData(locale.LocaleName));
        }
        PlayerData.getInstance().LoadGameSetting();
        languageDropDown.value = PlayerData.getInstance().Language;
        languageDropDown.onValueChanged.Invoke(PlayerData.getInstance().Language);
        languageDropDown.RefreshShownValue();
    }
    public void SetLanguage(int index) 
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        PlayerData.getInstance().Language = index;
        PlayerData.getInstance().SaveGameSetting();
    }

    public void statusCheck() 
    {
        InitVolume();
        InitializeLanguageDropDown();
        judgeVibrate();
        judgeFullScreen();
    }
    public void judgeVibrate() 
    {
        if (PlayerPrefs.GetInt("isVibrate") == 0)
        {
            controllerVibraton.isOn = false;
            isVibration = false;
        }
        else 
        {
            controllerVibraton.isOn = true;
            isVibration = true;
        }

    }

    public void ToggleVibrate(bool isVibrate) 
    {
        //Debug.Log(isVibrate);
        isVibration = isVibrate;
        if (isVibrate)
        {
            PlayerPrefs.SetInt("isVibrate", 1);
        }
        else 
        {
            PlayerPrefs.SetInt("isVibrate", 0);
        }
    }

    public void judgeFullScreen()
    {
        if (PlayerPrefs.GetInt("isFullScreen") == 0)
        {
            fullScreenController.isOn = false;
            isVibration = false;
        }
        else
        {
            fullScreenController.isOn = true;
            isVibration = true;
        }

    }

    public void ToggleFullScreen(bool isFullScreen)
    {
        Debug.Log(isFullScreen);
        Screen.fullScreen = isFullScreen;
        if (isFullScreen)
        {
            PlayerPrefs.SetInt("isFullScreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FullScreenate", 0);
        }
    }
    public void InitVolume() 
    {
        masterMixer.SetFloat("MasterMixer", PlayerPrefs.GetFloat("MasterMixer"));
        master.value = PlayerPrefs.GetFloat("MasterMixer");
        musicMixer.SetFloat("MusicMixer", PlayerPrefs.GetFloat("MusicMixer"));
        music.value = PlayerPrefs.GetFloat("MusicMixer");
        vfMixer.SetFloat("VFMixer", PlayerPrefs.GetFloat("VFMixer"));
        vf.value = PlayerPrefs.GetFloat("VFMixer");
    }
    public void SetMaserMixerVolume(float volume) 
    {
        masterMixer.SetFloat("MasterMixer", volume);
        PlayerPrefs.SetFloat("MasterMixer", volume);
    }
    public void SetMusicMixerVolume(float volume)
    {
        musicMixer.SetFloat("MusicMixer", volume);
        PlayerPrefs.SetFloat("MusicMixer", volume);
    }
    public void SetVFMixerVolume(float volume)
    {
        vfMixer.SetFloat("VFMixer", volume);
        PlayerPrefs.SetFloat("VFMixer", volume);
    }
}

