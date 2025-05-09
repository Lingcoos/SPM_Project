using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TitlePanelController : MonoBehaviour
{
    [SerializeField] private GameObject titileFirst;
    [SerializeField] private GameObject settingFirst;
    [SerializeField] private GameObject selectFirst;
    [SerializeField] private Animator[] anis;
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

    public void InitButton() 
    {
        foreach (var ani in anis) 
        {
            ani.Play("Normal");
        }
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
}


