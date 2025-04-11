using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Controller : MonoBehaviour
{
    public static Controller instance;
    public Gamepad pad;
    public bool isVibration;
    private void Start()
    {
        instance = this;
        pad = Gamepad.current;
    }

    public void StartVibration(float lowFequency, float highFequency, float duration) 
    {
        pad = Gamepad.current;
        if (pad == null) return; 
        pad.SetMotorSpeeds(lowFequency, highFequency);
        isVibration = true;
        Invoke("StopVibration",duration);
    }
    public void StopVibration() 
    {
        pad = Gamepad.current;
        if (pad == null) return;
        pad.SetMotorSpeeds(0f, 0f);
        isVibration = false;

    }

}
