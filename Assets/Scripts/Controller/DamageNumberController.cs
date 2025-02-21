using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public DamageNumber numberToSpawn;
    public Transform numberCanvas;
    public static DamageNumberController instance;
    private void Awake()
    {
        instance = this;
    }
    public void SpawnDamage(float damageAmount, Vector3 location) 
    {
        int rounded =Mathf.RoundToInt(damageAmount);
        //Instantiate(numberToSpawn, location, Quaternion.identity, numberCanvas)
        DamageNumber newDamage = ObjPoolManager.instance.GetObj("DamageNumber").GetComponent<DamageNumber>();
        newDamage.transform.position = location;
        newDamage.Setup(rounded);
        newDamage.gameObject.SetActive(true);
    }
}
