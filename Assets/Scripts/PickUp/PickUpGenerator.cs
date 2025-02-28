using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGenerator : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    public PropPrefab[] propPrefab;

    public void DropItems() 
    {
        Vector3 pos = transform.position;
        foreach (var propprefab in propPrefab) 
        {
            if (Random.Range(0f, 100f) <= propprefab.PropPercentage) 
            {
                GameObject item = ObjPoolManager.instance.GetObj(propprefab.prefabName);
                item.transform.position = pos + offset;
                //Instantiate(propprefab.prefab, pos + offset, Quaternion.identity);
            }
        }
    }
    
}




[System.Serializable]

public class PropPrefab 
{
    public string prefabName;
    public GameObject prefab;
    [Range(0f, 100f)] public float PropPercentage;
}
