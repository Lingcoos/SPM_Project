using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public Transform enemy;
    
    public SwordController weapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            if (collision.transform == enemy)
            {
                float damage = collision.GetComponent<Enemy>().maxHealht;
                collision.GetComponent<Enemy>().GetDamage(damage);
                DamageNumberController.instance.SpawnDamage(damage, collision.transform.position);

            }
            else
            {
                collision.GetComponent<Enemy>().GetDamage(weapon.damage + PlayerData.getInstance().ExtraDamge);
            DamageNumberController.instance.SpawnDamage(weapon.damage + PlayerData.getInstance().ExtraDamge, collision.transform.position);
            }

        }
    }
    private void Start()
    {
        weapon = FindObjectOfType<SwordController>();



    }
    
}
