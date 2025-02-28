using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FunnelController : WeaponController
{
    public GameObject rotationPoint;

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < count; i++)
        {
            Vector3 rota = Vector3.forward * 360 * i / count;
            Transform funnel = Instantiate(prefab, rotationPoint.transform.position, Quaternion.identity, rotationPoint.transform).transform;
            funnel.Rotate(rota);
            funnel.Translate(funnel.up * 1f, Space.World);

        }
    }
    protected override void Attack()
    {
        base.Attack();
        Debug.Log("¹¥»÷£¡£¡");
    }
    protected override void CDTime()
    {
        Rotation();
    }
    protected override void Refresh()
    {
        for(int i = 0; i < count; i++) 
        {
            Vector3  rota = Vector3.forward * 360 *i / count;
            Transform funnel = Instantiate(prefab, rotationPoint.transform.position, Quaternion.identity, rotationPoint.transform).transform;
            funnel.Rotate(rota);
            funnel.Translate(funnel.up* 1.5f,Space.World);

        }
    }
    public void Rotation() 
    {
        rotationPoint.transform.rotation = Quaternion.Euler(0f, 0f, rotationPoint.transform.rotation.eulerAngles.z + (speed * Time.deltaTime));
    }
}
