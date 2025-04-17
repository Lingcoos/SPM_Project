using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TitlePanelController : MonoBehaviour
{
    [SerializeField] private GameObject titileFirst;
    [SerializeField] private GameObject settingFirst;
    [SerializeField] private GameObject selectFirst;


    private void Start()
    {
        TitleOpen();
    }
    public void TitleOpen()
    {
        EventSystem.current.SetSelectedGameObject(titileFirst);
        InputController.instance.firstSelectedUI = titileFirst;
    }
    public void SettingOpen() 
    {
        
        EventSystem.current.SetSelectedGameObject(settingFirst);
        InputController.instance.firstSelectedUI = settingFirst;
    }
    public void SelectOpen() 
    {
        EventSystem.current.SetSelectedGameObject(selectFirst);
        InputController.instance.firstSelectedUI = selectFirst;
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}


