using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using Mirror;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public static InputController instance;
    public GameObject firstSelectedUI;
    private EventSystem eventSystem;
    private InputDevice currentDevice;
    private InputDevice lastDevice;
    private void Awake()
    {
        instance = this;
        eventSystem = EventSystem.current;

    }
    private void Update()
    {
        DetectInputDevice();
        HandleUIInteraction();
        
    }
    void DetectInputDevice()
    {
        InputDevice newDevice = GetActiveInputDevice();

        if (newDevice != lastDevice) 
        {
            //Debug.Log("«–ªª");
            lastDevice =currentDevice;
            currentDevice = newDevice;
            HandleSwitchDevice();
        }
    }

    InputDevice GetActiveInputDevice() 
    {
        if (Gamepad.current != null && (Gamepad.current.leftStick.ReadValue().magnitude > 0.1f ||
            Gamepad.current.buttonSouth.isPressed)) 
        {
            //Debug.Log("«–ªª ÷±˙");
            return Gamepad.current;

        }
        if (Keyboard.current.anyKey.isPressed || Mouse.current.delta.ReadValue().magnitude > 0) 
        {
            //Debug.Log("«–ªªº¸≈Ã");
            SetGamepadUIState(false);
            return Keyboard.current;
        }
        return null;
    }

    void HandleSwitchDevice() 
    {
        
        bool isSwitchingToGamepad = currentDevice is Gamepad;
        bool isSwitchingToKeyboard = currentDevice is Keyboard;
        bool isSwitchingFromGamepad = lastDevice is Gamepad;
        bool isSwitchingStay = currentDevice is null;

        if (isSwitchingToGamepad)
        {
            //Debug.Log("À¯ Û±Í");
            SetGamepadUIState(true);
            return;
        }
    }
    void SetGamepadUIState(bool enableGamepadMode)
    {
        Cursor.visible = !enableGamepadMode;
        Cursor.lockState = enableGamepadMode ? CursorLockMode.Locked : CursorLockMode.None;

        if (enableGamepadMode)
        {
            eventSystem.SetSelectedGameObject(firstSelectedUI);
        }
        else
        {
            eventSystem.SetSelectedGameObject(null);
        }
    }
    void HandleUIInteraction()
    {

        if (lastDevice is Keyboard || eventSystem.currentSelectedGameObject == null &&firstSelectedUI != null)
        {
            eventSystem.SetSelectedGameObject(null);
        }

    }
}
