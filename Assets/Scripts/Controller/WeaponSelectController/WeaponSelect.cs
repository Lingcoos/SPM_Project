using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponSelect : MonoBehaviour
{
    [SerializeField] private WeaponType weaponType;
    public UnityEvent<int> levelUp;
    public enum WeaponType 
    {
        knife, scythe,missile
    }
    public void LevelUp() 
    {
        switch (weaponType) 
        {
            case WeaponType.knife:
                levelUp.Invoke(0);
                break;

            case WeaponType.scythe:
                levelUp.Invoke(1);
                break;
            case WeaponType.missile:
                levelUp.Invoke(2);
                break;
        }
    }
}
