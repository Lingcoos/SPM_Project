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
            collision.GetComponent<Enemy>().GetDamage(weapon.damage+ PlayerData.getInstance().ExtraDamge);
            DamageNumberController.instance.SpawnDamage(weapon.damage + PlayerData.getInstance().ExtraDamge,collision.transform.position);
        }
    }
}
