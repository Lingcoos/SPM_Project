using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public GameObject[] weaponList;
    public List<GameObject> weaponBag;
    private int levelUpID;

    private void Start()
    {
        
    }
    public void GetWeapon(int id) 
    {
        if (CheckWeapon(weaponList[id]))
        {
            weaponList[id].SetActive(true);
            weaponBag.Add(weaponList[id]);
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
        //foreach (var weapon in weaponBag) 
        //{
        //    if (weapon == obj)
        //    { 
        //        return false;
        //    }
        //}
        //return true;
    }
}
