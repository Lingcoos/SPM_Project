using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy")) 
        {
            //Debug.Log("Hit!");
            collision.GetComponent<Enemy>().Health -= transform.parent.parent.GetComponent<KnifeController>().damage;
        }
    }
}
