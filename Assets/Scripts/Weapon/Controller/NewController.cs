using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : WeaponController
{
    public GameObject rotationPoint;

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < count; i++)
        {
            Vector3 rota = Vector3.forward * 360 * i / count;
            Transform tornado = Instantiate(prefab, rotationPoint.transform.position, Quaternion.identity, rotationPoint.transform).transform;
            tornado.Rotate(rota);
            tornado.Translate(tornado.up * 5f, Space.World);
            tornado.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
    protected override void Attack()
    {
        base.Attack();
        rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, rotationPoint.transform.rotation.eulerAngles.z + (speed * Time.deltaTime));

    }
    protected override void Refresh()
    {

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
                WeaponSelectController.instance.LevelMaxRemove("Funnel");
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
