using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class ScytheController : WeaponController
{
    public GameObject shootPoint;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        for (int i = 0; i < count; i++)
        {
            Vector3 dir = Vector3.forward * 360 * i / count;
            Transform scythe = Instantiate(prefab, shootPoint.transform.position, Quaternion.identity, shootPoint.transform).transform;
            scythe.Rotate(dir);
        }
    }
    public float returnTimer()
    {
        return timer;
    }

    public void levelUp()
    {
        switch (level) 
        {
            case 0:
                level++;
                break;
            case 1:
                level++;
                break;
            case 2:
                count += 2;
                level++;
                break;
            case 3:
                level++;
                break;
            case 4:
                count += 2;
                level++;
                break;
            case 5:
                GetComponent<Weapon>().isLevelMax = true;
                WeaponSelectController.instance.LevelMaxRemove("Scythe");
                weapon.weaponLevel++;
                break;
        }
        
        

    }

}
