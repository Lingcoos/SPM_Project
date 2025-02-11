using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ScytheController : WeaponController
{
    public GameObject shootPoint;



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
        level++;
        count+=2;

    }
}
