using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolManager : MonoBehaviour
{
    public static ObjPoolManager instance;

    public List<ObjPool> pools = new List<ObjPool>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            InitializeAllPools();
        }
        else 
        { 
            Destroy(gameObject);
         }
    }
    private void InitializeAllPools() //初始化对象池
    {
        foreach (var pool in pools) 
        {
            pool.Initiliza();
        }
    }
    public GameObject GetObj(string name) //获取对象
    {
        var pool = pools.Find(p => p.poolName == name);
        if(pool != null)
            return pool.GetObj();
        return null;
    }
    public void ReturnObj(GameObject obj) //返回对象池中
    {
        foreach (var pool in pools) 
        {
            if(pool.allObjects.Contains(obj))
            {
                pool.ReturnObj(obj);
                return;
            }
        }
    }
}
