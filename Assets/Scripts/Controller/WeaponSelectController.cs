using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectController : MonoBehaviour
{
    public GameObject box;
    public GameObject leftGrid;
    public GameObject rightGrid;
    public GameObject midGrid;
    private GameObject left;
    private GameObject right;
    private GameObject mid;


    public void WeapSelect() 
    {
        box.SetActive(true);
        Time.timeScale = 0f;
    }



}
