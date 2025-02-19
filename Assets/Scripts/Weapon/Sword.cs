using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float rotationSpeed;
    private Quaternion targetRotation;
    public Transform enemy;
    
    public SwordController weapon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            collision.GetComponent<Enemy>().GetDamage(weapon.damage);
            DamageNumberController.instance.SpawnDamage(weapon.damage, collision.transform.position);
        }
    }
    private void Start()
    {
        weapon = FindObjectOfType<SwordController>();



    }
    private void Update()
    {


    }

    private void FixedUpdate()
    {
        //MoveObject();
        //RotationSword();
    }
    //public void MoveObject()
    //{

    //    transform.position = Vector3.MoveTowards(transform.position, enemy.position, weapon.speed * Time.deltaTime);
    //}
    //public void RotationSword()
    //{

    //    Vector2 dir = transform.position - enemy.position;
    //    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //    Quaternion targetRotation = Quaternion.Euler(0, 0, angle + 45f);
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, weapon.turnSpeed * Time.deltaTime);
    //    if (transform.rotation == targetRotation)
    //    {
    //        weapon.isRotating = false;
    //    }
    //}

}
