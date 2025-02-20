using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class GameSettingController : MonoBehaviour
{
    [Header("����")]
    public Dropdown languageDropDown;
    
    [Header("�ֱ���")]
    public TMP_Dropdown resolutionDropDown;
    [SerializeField]private Resolution[] resolutions;
    private void Awake()
    {
        Screen.fullScreen = true;
    }
    private void Start()
    {
        InitializeLanguageDropDown();
        resolutions =Screen.resolutions;
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

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ToggleFullScreen(bool isFullScreen) 
    {
        Screen.fullScreen =isFullScreen;
    }
    public void InitializeLanguageDropDown() 
    {
        languageDropDown.ClearOptions();
        var locales =LocalizationSettings.AvailableLocales.Locales;
        foreach (var locale in locales) 
        {
            languageDropDown.options.Add(new Dropdown.OptionData(locale.LocaleName));
        }
        
        languageDropDown.RefreshShownValue();
    }
    public void SetLanguage(int index) 
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }


}

