using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public GameObject[] weaponList;
    public List<GameObject> weaponBag;
    private Weapon weapon;
    private int levelUpID;

    private void Start()
    {
        
    }
    public void GetWeapon(int index) //ÅÐ¶ÏÎäÆ÷ÊÇ·ñ»ñµÃ
    {
        if (CheckWeapon(weaponList[index]))
        {
            weaponList[index].SetActive(true);
            weaponBag.Add(weaponList[index]);
            
        }
        else
        {
            weaponBag[levelUpID].GetComponent<Weapon>().LevelUp();
        }
    }


    public bool CheckWeapon(GameObject obj) 
    {
        for (int i = 0; i < weaponBag.Count; i++) 
        {
            if (weaponBag[i] == obj) 
            {
                levelUpID = i;
                return false;
            }
        }
        return true;

    }

}
