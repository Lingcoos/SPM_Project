using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public int weaponId;
    public string weaponName;
    public bool isLevel = true;
    public UnityEvent levelUp;
    
    public void LevelUp() 
    { 
        levelUp?.Invoke();
     }

}
