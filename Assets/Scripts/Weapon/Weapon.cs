using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(WeaponController))]
public class Weapon : MonoBehaviour
{
    public int weaponId;
    public int weaponLevel;
    public string weaponName;
    public bool isLevelMax;
    public bool isGet;
    public UnityEvent levelUp;

    //private void OnEnable()
    //{
    //    isGet = true;
    //}
    public void LevelUp() 
    {
        levelUp?.Invoke();
        
    }
    

}
