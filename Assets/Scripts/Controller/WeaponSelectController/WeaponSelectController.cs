using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectController : MonoBehaviour
{
    public List<GameObject> weaponList;
    public GameObject box;
    public GameObject leftGrid;
    public GameObject rightGrid;
    public GameObject midGrid;
    private GameObject left;
    private GameObject right;
    private GameObject mid;
    public GameObject test;
    public GameObject test2;
    public GameObject test3;

    private void Start()
    {
        left = test;
        mid = test2;
        right = test3;
    }

    public void WeapSelect() 
    {
        box.SetActive(true);
        Time.timeScale = 0f;
    }
    #region Check
    public void CheckLeft() 
    {
        left.GetComponent<WeaponSelect>().LevelUp();
        Time.timeScale = 1f;
        box.SetActive(false);

    }
    public void CheckMid()
    {
        mid.GetComponent<WeaponSelect>().LevelUp();
        Time.timeScale = 1f;
        box.SetActive(false);

    }
    public void CheckRight()
    {
        right.GetComponent<WeaponSelect>().LevelUp();
        Time.timeScale = 1f;
        box.SetActive(false);

    }
    #endregion


}
