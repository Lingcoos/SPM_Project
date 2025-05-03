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
            collision.GetComponent<Enemy>().GetDamage(weapon.damage + PlayerData.getInstance().ExtraDamge);
            DamageNumberController.instance.SpawnDamage(weapon.damage + PlayerData.getInstance().ExtraDamge, collision.transform.position);
        }
    }

    public void LaserDestory()
    {
        Destroy(gameObject);
    }
}
