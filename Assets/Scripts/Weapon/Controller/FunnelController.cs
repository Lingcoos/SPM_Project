using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FunnelController : WeaponController
{
    public GameObject rotationPoint;
    public GameObject laser;
    public List<GameObject> funnels;



    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < count; i++)
        {
            Vector3 rota = Vector3.forward * 360 * i / count;
            Transform funnel = Instantiate(prefab, rotationPoint.transform.position, Quaternion.identity, rotationPoint.transform).transform;
            funnels.Add(funnel.gameObject);
            funnel.Rotate(rota);
            funnel.Translate(funnel.up * 1f, Space.World);

        }
    }
    protected override void Attack()
    {
        base.Attack();
        ShootLaser(funnels);
    }
    protected override void CDTime()
    {
        Rotation();
    }
    protected override void Refresh()
    {
        funnels.Clear();
        for (int i = 0; i < count; i++) 
        {
            Vector3  rota = Vector3.forward * 360 *i / count;
            Transform funnel = Instantiate(prefab, rotationPoint.transform.position, Quaternion.identity, rotationPoint.transform).transform;
            funnels.Add(funnel.gameObject);
            funnel.Rotate(rota);          
            funnel.Translate(funnel.up* 1.5f,Space.World);

        }
    }
    public void Rotation() 
    {
        rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, rotationPoint.transform.rotation.eulerAngles.z + (speed * Time.deltaTime));
    }
    public void ShootLaser(List<GameObject> objs) 
    {
        for (int i = 0; i < objs.Count; i++) 
        {
            Instantiate(laser, objs[i].transform.position, objs[i].transform.rotation * Quaternion.Euler(0, 0, 90f), objs[i].transform);
        }
        
    }
    public void levelUp()
    {
        switch (level)
        {
            case 0:
                
                level++;
                break;
            case 1:
                count++;
                level++;
                break;
            case 2:
                damage+=5;
                level++;
                break;
            case 3:
                count++;
                level++;
                break;
            case 4:
                speed*=2;
                level++;
                break;
            case 5:
                cooldownDuration /= 2;
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
