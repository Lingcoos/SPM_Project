using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissileController : WeaponController
{
    
    public float missileAttackRangeOut;
    public float missileAttackRangeIn;


    protected override void Attack()
    {
        base.Attack();
        for (int i = 0; i < count; i++) 
        {
            float radius = Random.Range(missileAttackRangeIn, missileAttackRangeOut);
            float angle = Random.Range(0f, 2f * Mathf.PI);
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            Vector2 attackPosition = new Vector2(x, y);            
            GameObject missle = Instantiate(prefab, (Vector2)transform.position+ attackPosition, Quaternion.identity);            

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
                cooldownDuration -= 1;
                
                level++;
                break;
            case 2:
                damage += 10;
                level++;
                break;
            case 3:
                
                level++;
                break;
            case 4:
                timer /= 2;
                level++;
                break;
            case 5:
                damage *= 2;
                GetComponent<Weapon>().isLevelMax = true;
                WeaponSelectController.instance.LevelMaxRemove("Missile");
                weapon.weaponLevel++;
                break;
        }

    }
    private void MissileDestroy(GameObject obj)
    {
        Destroy(obj);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(transform.position, missileAttackRangeOut);
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, missileAttackRangeIn);
    //}
}
