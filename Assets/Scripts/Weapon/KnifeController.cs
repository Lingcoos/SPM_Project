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
            newKnife.Translate(newKnife.up * 1.5f, Space.World);
        }
    }



    protected override void Attack()
    {
        base.Attack();
        rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, rotationPoint.transform.rotation.eulerAngles.z + (speed * Time.deltaTime));

    }
    public void levelUp() 
    {
        level++;
        count++;
        for (int i = 0; i < transform.GetChild(0).childCount; i++) 
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
        }
        Refresh();
    }
    
}
