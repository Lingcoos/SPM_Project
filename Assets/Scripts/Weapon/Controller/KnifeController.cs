using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    public GameObject rotationPoint;
    

    
    protected override void Start()
    {
        
        Refresh();
       
    }
    protected override void Refresh()
    {
        base.Start();
        for (int i = 0; i < count; i++)
        {
            Vector3 rota = Vector3.forward * 360 * i / count;
            Transform newKnife = Instantiate(prefab, rotationPoint.transform.position, Quaternion.identity, rotationPoint.transform).transform;
            newKnife.Rotate(rota);
            newKnife.Translate(newKnife.up * 2f, Space.World);
        }
    }



    protected override void Attack()
    {
        base.Attack();
        rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, rotationPoint.transform.rotation.eulerAngles.z + (speed * Time.deltaTime));

    }
    public void levelUp() 
    {
        switch (level)
        {
            case 0:
                count++;
                level++;
                break;
            case 1:
                count++;
                level++;
                break;
            case 2:
                count++;
                level++;
                break;
            case 3:
                count++;
                level++;
                break;
            case 4:
                count++;
                level++;
                break;
            case 5:
                GetComponent<Weapon>().isLevelMax = true;
                WeaponSelectController.instance.LevelMaxRemove("Knife");
                weapon.weaponLevel++;
                break;
        }
        for (int i = 0; i < transform.GetChild(0).childCount; i++) 
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
        }
        Refresh();
    }
    
}
