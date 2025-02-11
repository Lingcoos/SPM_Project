using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private CapsuleCollider2D col;
    private MissileController weapon;
    private SpriteRenderer sr;
    private Color originColor;
    private Color targetColor;
    private float startTime;
    
    private void Start()
    {
        col = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        originColor = sr.color;
        targetColor = Color.red;
        weapon = FindObjectOfType<MissileController>();
        startTime = Time.time;

    }
    private void Update()
    {
        Aiming();
        Fire();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().GetDamage(weapon.damage);
            DamageNumberController.instance.SpawnDamage(weapon.damage, collision.transform.position);
        }
    }
    public void Fire() 
    {
        if (sr.color == targetColor) 
        {
            col.enabled = true;
            Invoke("MissileDestroy", 0.1f);
        }
    }
    public void Aiming() 
    {
        float time = (Time.time - startTime) / weapon.timer;
        time = Mathf.Clamp01(time);
        sr.color =Color.Lerp(originColor, targetColor, time);
    }
    private void MissileDestroy() 
    {
        Destroy(gameObject);
    }
}
