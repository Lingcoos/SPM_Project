using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    void OnEnter();   
    void OnUpData();
    void OnFixUpData();
    void OnExit();
}