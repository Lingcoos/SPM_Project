using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TornadoController : WeaponController
{
    public float moveRange;
    public List<GameObject> tornado;
    private Vector3 newPos;
    private float startTime;
    private Vector3 originPos;
    private float distance;
    private bool isAttack;

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < count; i++)
        {
            tornado.Add(Instantiate(prefab, transform.position + new Vector3(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange), 0), Quaternion.identity));
        }
    }
    protected override void Refresh()
    {
        tornado.Clear();
        for (int i = 0; i < count; i++) 
        {
            tornado.Add(Instantiate(prefab, transform.position + new Vector3(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange), 0), Quaternion.identity));
        }
        
    }
    protected override void Update()
    {
        weapon.weaponLevel = level;
        //if (!isAttack)
        //    Attack();
        //else 
        //{            
        //    float dist = (Time.time - startTime) * speed;
        //    float factor = dist / distance;
        //    Debug.Log(factor);
        //    tornado.transform.position = Vector3.Lerp(originPos, newPos, factor);
        //    if(tornado.transform.position == newPos)
        //        isAttack = false;
        //}
            
    }
    protected override void Attack()
    {
        //startTime = Time.time;
        //base.Attack();
        //float newX = transform.position.x+Random.Range(-moveRange, moveRange);
        //float newY = transform.position.y+Random.Range(-moveRange, moveRange);
        //newPos = new Vector3 (newX, newY, 0);
        //originPos = tornado.transform.position;
        //distance = Vector3.Distance(originPos,new Vector3(newX,newY,0));
        //isAttack = true;
            
    }
    public void levelUp()
    {
        switch (level)
        {
            case 0:

                level++;
                break;
            case 1:
                damage++;
                level++;
                break;
            case 2:
                count++;
                level++;
                break;
            case 3:
                moveRange--;
                level++;
                break;
            case 4:
                damage+=2;
                level++;
                break;
            case 5:
                moveRange -= 2;
                GetComponent<Weapon>().isLevelMax = true;
                WeaponSelectController.instance.LevelMaxRemove("Funnel");
                weapon.weaponLevel++;
                break;
        }
        for (int i = 0; i < tornado.Count; i++)
        {
            Destroy(tornado[i]);
        }
        Refresh();
    }
}
