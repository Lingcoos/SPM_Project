using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private FunnelController weapon;
    private void Start()
    {
        weapon = FindObjectOfType<FunnelController>();
    }
    private void OnEnable()
    {
        Invoke("LaserDestory", 0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            collision.GetComponent<Enemy>().GetDamage(weapon.damage);
            DamageNumberController.instance.SpawnDamage(weapon.damage, collision.transform.position);
        }
    }

    public void LaserDestory()
    {
        Destroy(gameObject);
    }
}
