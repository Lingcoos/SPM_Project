using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.UI;

public class EscController : MonoBehaviour
{

    [SerializeField] private UnityEvent openPanel;
    public Text tipText;
    public LocalizedString[] tipString;
    private void OnEnable()
    {
        openPanel.Invoke();
        tipText.text = tipString[Random.Range(0, tipString.Length)].GetLocalizedString();
    }

}
