using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    KnifeController weapon;
    private void Start()
    {
        weapon = transform.parent.parent.GetComponent<KnifeController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy")) 
        {
            collision.GetComponent<Enemy>().GetDamage(weapon.damage);
            DamageNumberController.instance.SpawnDamage(weapon.damage,collision.transform.position);
        }
    }
}
