using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class WeaponSelectController : MonoBehaviour
{
    public List<GameObject> weaponList;
    public GameObject box;
    public GameObject leftPosition;
    public GameObject rightPosition;
    public GameObject midPosition;
    private GameObject left;
    private GameObject right;
    private GameObject mid;
    public List<GameObject> selectWeapon;
    public static WeaponSelectController instance;
    private void Awake()
    {
        instance = this;
       
    }
    public void GenerateSelect() // π”√œ¥≈∆À„∑®
    {
        for (int i = 0; i < selectWeapon.Count; i++) 
        {
            int randomIndex = Random.Range(i, selectWeapon.Count);
            //while (selectWeapon[randomIndex].GetComponent<WeaponSelect>().weapon.isLevelMax) 
            //{
            //    randomIndex = Random.Range(i, selectWeapon.Count);
            //}

            GameObject temp = selectWeapon[i];
            selectWeapon[i] = selectWeapon[randomIndex];
            selectWeapon[randomIndex] = temp;
        }

        left = Instantiate(selectWeapon[0], leftPosition.transform.position, Quaternion.identity, leftPosition.transform);
        mid = Instantiate(selectWeapon[1], midPosition.transform.position, Quaternion.identity, midPosition.transform);
        right = Instantiate(selectWeapon[2], rightPosition.transform.position, Quaternion.identity, rightPosition.transform);
    }

    public void WeapSelect() 
    {
        //selectWeapon = weaponList;
        left = null;
        right = null;
        mid = null;
        GenerateSelect();
        box.SetActive(true);
        Time.timeScale = 0f;
    }
    #region Check
    public void CheckLeft() //Left button check event
    {
        left.GetComponent<WeaponSelect>().LevelUp();
        Time.timeScale = 1f;
        box.SetActive(false);
        FinishSelect();
    }
    public void CheckMid()//Mid button check event
    {
        mid.GetComponent<WeaponSelect>().LevelUp();
        Time.timeScale = 1f;
        box.SetActive(false);
        FinishSelect();
    }
    public void CheckRight()//Right button check event
    {
        right.GetComponent<WeaponSelect>().LevelUp();
        Time.timeScale = 1f;
        box.SetActive(false);
        FinishSelect();

    }
    #endregion
    public void FinishSelect() 
    {
        Destroy(left);
        Destroy(mid);
        Destroy(right);
    }
    public void LevelMaxRemove(string name) 
    {
        selectWeapon.RemoveAll(obj =>obj.name == name);
    }

}
