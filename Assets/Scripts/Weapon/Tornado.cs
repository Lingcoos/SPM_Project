using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TestTools;
using static Cinemachine.DocumentationSortingAttribute;

public class Tornado : MonoBehaviour
{
    private TornadoController weapon;
    private float startTime;
    private float distance;
    private Vector3 originPos;
    private Vector3 newPos;
    private bool isAttack;
    
    private void Start()
    {

        weapon = FindObjectOfType<TornadoController>();
    }
    private void Update()
    {
        if (!isAttack)
            Attack();
        else
        {
            float dist = (Time.time - startTime) * weapon.speed;
            float factor = dist / distance;
            transform.position = Vector3.Lerp(originPos, newPos, factor);
            if (transform.position == newPos) 
            {
                isAttack = false;
                originPos = transform.position;
                Debug.Log("ÇÐ»»Ä¿±ê");
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().GetDamage(weapon.damage);
            DamageNumberController.instance.SpawnDamage(weapon.damage, collision.transform.position);
            collision.GetComponent<Enemy>().enemySpeed /= 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().enemySpeed *= 2;
        }
    }
    private void Attack() 
    {
        
        startTime = Time.time;
        float newX = weapon.transform.position.x + Random.Range(-weapon.moveRange, weapon.moveRange);
        float newY = weapon.transform.position.y + Random.Range(-weapon.moveRange, weapon.moveRange);
        newPos = new Vector3(newX, newY, 0);
        distance = Vector3.Distance(originPos, new Vector3(newX, newY, 0));
        isAttack = true;
    }

}
