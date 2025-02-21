using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjPool 
{
    public string poolName;
    public GameObject prefab;
    public int size;
    public int expandSize;
    public Transform parentTransform;

    private Stack<GameObject> inactiveObjects = new Stack<GameObject>();
    public List<GameObject> allObjects = new List<GameObject>();

    public void Initiliza() 
    {
        if(prefab == null)
        {
            return;
        }
        PreWarmPool(size);
    }

    private void PreWarmPool(int num) //预热
    {
        for (int i = 0; i < num; i++) 
        { 
            CreateNewObj();
        }
    }
    public GameObject GetObj() //获取对象
    {
        if (inactiveObjects.Count > 0) 
        {
            var obj = inactiveObjects.Pop();
            obj.SetActive(true);
            return obj;
        }
        ExpandPool();
        return GetObj();
    }
    public void ReturnObj(GameObject obj) 
    {
        if (!allObjects.Contains(obj)) 
        {
            return ;
        }
        obj.SetActive(false);
        inactiveObjects.Push(obj);
        if(parentTransform != null) 
            obj.transform.SetParent(parentTransform); 
    }
    private GameObject CreateNewObj() 
    {
        var newObj = Object.Instantiate(prefab, parentTransform);
        newObj.SetActive(false);
        allObjects.Add(newObj);
        inactiveObjects.Push(newObj);
        return newObj;
    }
    private void ExpandPool() //扩充对象池
    {
        PreWarmPool(expandSize);
    }
    public void Clear() 
    {
        foreach (var obj in allObjects) 
        {
            Object.Destroy(obj);
        }
        inactiveObjects.Clear();
        allObjects.Clear();
    }
}
