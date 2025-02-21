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
    private void InitializeAllPools() //��ʼ�������
    {
        foreach (var pool in pools) 
        {
            pool.Initiliza();
        }
    }
    public GameObject GetObj(string name) //��ȡ����
    {
        var pool = pools.Find(p => p.poolName == name);
        if(pool != null)
            return pool.GetObj();
        return null;
    }
    public void ReturnObj(GameObject obj) //���ض������
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
