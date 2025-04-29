using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonStateDetector : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    ISelectHandler,     
    IDeselectHandler    
{
    public UnityEvent playMusic;
    public enum ButtonState { Normal, Highlighted, Pressed, Disabled, Selected }
    public ButtonState currentState = ButtonState.Normal;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        // ��ʼ״̬
        currentState = button.interactable ? ButtonState.Normal : ButtonState.Disabled;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button.interactable) 
        {
            currentState = ButtonState.Highlighted;
            playMusic.Invoke();
        }
 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (button.interactable)
            currentState = ButtonState.Normal;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (button.interactable)
            currentState = ButtonState.Pressed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (button.interactable)
            currentState = ButtonState.Highlighted; // ����������ڰ�ť��
    }
    public void OnSelect(BaseEventData eventData)
    {
        if (button.interactable)
        {
            currentState = ButtonState.Selected;
            playMusic.Invoke();
        }     
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (button.interactable)
            currentState = ButtonState.Normal;
        
    }
    void Update()
    {
        // �������״̬
        if (!button.interactable)
            currentState = ButtonState.Disabled;
    }
}

