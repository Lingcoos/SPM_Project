using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject EscFirst;
    [SerializeField] private GameObject settingFirst;
    [SerializeField] private GameObject selectFirst;


    public void EscOpen() 
    {
        EventSystem.current.SetSelectedGameObject(EscFirst);
        InputController.instance.firstSelectedUI = EscFirst;
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
}
