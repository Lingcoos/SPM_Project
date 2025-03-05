using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
public enum WeaponType 
    {
        knife, scythe,missile,sword,funnel
    }
public class WeaponSelect : MonoBehaviour
{
    public int id;
    public string weaponName;
    [SerializeField] private WeaponType weaponType;
    [HideInInspector]public Weapon weapon;
    [HideInInspector]public WeaponList weaponList;
    public Text nameBox;
    public Text describle;

    public LocalizedString describleString;
    public LocalizedString nameString;
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
        int level = weapon.weaponLevel;
        nameString.TableEntryReference = $"{weaponType}";
        nameBox.text = $"Lv.{level} {nameString.GetLocalizedString()}";
        describleString.TableEntryReference = $"{weaponType}Level{level}";
        describle.text = describleString.GetLocalizedString();

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
            case WeaponType.sword:
                weaponList.GetWeapon(3);
                ChangeGet();
                break;
            case WeaponType.funnel:
                weaponList.GetWeapon(4);
                ChangeGet();
                break;
        }
    }
}
