using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
    public Animator ani;

    private void Awake()
    {
        instance = this;
       
    }
    private void Start()
    {
        GameObject player= FindObjectOfType<Player>().gameObject;
        ani = player.GetComponent<Animator>();
    }
    public void GenerateSelect() //ʹ��ϴ���㷨
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
        ani.enabled = false;
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
        ani.enabled = true;
        FinishSelect();
        
    }
    public void CheckMid()//Mid button check event
    {
        mid.GetComponent<WeaponSelect>().LevelUp();
        Time.timeScale = 1f;
        box.SetActive(false);
        ani.enabled = true;
        FinishSelect();
        
    }
    public void CheckRight()//Right button check event
    {
        right.GetComponent<WeaponSelect>().LevelUp();
        Time.timeScale = 1f;
        box.SetActive(false);
        ani.enabled = true;
        FinishSelect();

    }
    #endregion
    public void FinishSelect() //Clear Weapon Selection when finish selecting
    {
        Destroy(left);
        Destroy(mid);
        Destroy(right);
    }
    public void LevelMaxRemove(string name) //Use name to remove weapon when its level reach max
    {
        selectWeapon.RemoveAll(obj =>obj.name == name);
    }

}
