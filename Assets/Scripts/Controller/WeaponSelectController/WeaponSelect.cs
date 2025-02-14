using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
    public enum WeaponType 
    {
        knife, scythe,missile,Sword
    }
public class WeaponSelect : MonoBehaviour
{
    public int id;
    public string weaponName;
    [SerializeField] private WeaponType weaponType;
    [HideInInspector]public Weapon weapon;
    [HideInInspector]public WeaponList weaponList;
    public TMP_Text nameBox;
    public TMP_Text describle;
    public string[] levelDescrible;

    private void Start()
    {
        
        weaponList = FindObjectOfType<WeaponList>();
        weapon = weaponList.weaponList[id-1].GetComponent<Weapon>();
    }
    private void Update()
    {
        DescribleGenerator();
    }
    public void DescribleGenerator() //Updata Describle of Selection Weapoin
    {
        if (!weapon.isGet)
        {
            //Debug.Log("没有获得");
            nameBox.text = "New! " + weaponName;
        }
        else 
        {        
            switch (weapon.weaponLevel)
            {
                case 1:
                    describle.text = levelDescrible[0];
                    nameBox.text = "Level 1 " + weaponName;
                    break;
                case 2:
                    describle.text = levelDescrible[1];
                    nameBox.text = "Level 2 " + weaponName;
                    break;
                case 3:
                    describle.text = levelDescrible[2];
                    nameBox.text = "Level 3 " + weaponName;
                    break;
                case 4:
                    describle.text = levelDescrible[3];
                    nameBox.text = "Level 4 " + weaponName;
                    break;
                case 5:
                    describle.text = levelDescrible[4];
                    nameBox.text = "Level 5 " + weaponName;
                    break;
            }
        }
    }
    public void ChangeGet() //Change Weapon whether get
    {
        weapon.isGet = true;
    }

    public void LevelUp() //Judge which weapon want to select to level up
    {
        switch (weaponType) 
        {
            case WeaponType.knife:
                weaponList.GetWeapon(0);
                ChangeGet();
                break;

            case WeaponType.scythe:
                weaponList.GetWeapon(1);
                ChangeGet();
                break;
            case WeaponType.missile:
                weaponList.GetWeapon(2);
                ChangeGet();
                break;
            case WeaponType.Sword:
                weaponList.GetWeapon(3);
                ChangeGet();
                break;
        }
    }
}
