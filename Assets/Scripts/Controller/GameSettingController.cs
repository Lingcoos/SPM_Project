using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class GameSettingController : MonoBehaviour
{
    [Header("语言")]
    public Dropdown languageDropDown;
    
    [Header("分辨率")]
    public TMP_Dropdown resolutionDropDown;
    [SerializeField]private Resolution[] resolutions;

    private float timeDelta = 0.5f;
    private float prevTime;
    private float fps;
    private int frames;

    private GUIStyle style;
    private void Awake()
    {
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
    public void ToggleFullScreen(bool isFullScreen) 
    {
        Screen.fullScreen =isFullScreen;
    }
    private void InitialzieResolutionDropDown() //分辨率初始化
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
    public void InitializeLanguageDropDown() //语言切换初始化
    {
        languageDropDown.ClearOptions();
        var locales =LocalizationSettings.AvailableLocales.Locales;
        foreach (var locale in locales) 
        {
            languageDropDown.options.Add(new Dropdown.OptionData(locale.LocaleName));
        }
        PlayerData.getInstance().LoadGameSetting();
        languageDropDown.value = PlayerData.getInstance().Language;
        languageDropDown.RefreshShownValue();
    }
    public void SetLanguage(int index) 
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        PlayerData.getInstance().Language = index;
        PlayerData.getInstance().SaveGameSetting();
    }


}

