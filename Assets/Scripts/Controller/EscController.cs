using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscController : MonoBehaviour
{

    [SerializeField] private UnityEvent openPanel;
    private void OnEnable()
    {
        openPanel.Invoke();       
    }
}
