using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public AnimationClip targetAnimation;




    private Animator ani;
    private float originSpeed;
    private CapsuleCollider2D col;
    private MissileController weapon;
    private SpriteRenderer sr;
    private Color originColor;
    private Color targetColor;
    private float startTime;
    
    private void Start()
    {
        ani = GetComponent<Animator>();
        originSpeed = ani.speed;
        col = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        originColor = sr.color;
        targetColor = Color.red;
        weapon = FindObjectOfType<MissileController>();
        startTime = Time.time;


        float animationLength = targetAnimation.length;
        ani.speed = animationLength/weapon.timer;
    }
    private void Update()
    {
        //Aiming();

    }


    public void SetAnimationDuration(float newDuration) 
    {
        float animationLength = targetAnimation.length;
        ani.speed = animationLength / newDuration;
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
        col.enabled = true;
        Invoke("MissileDestroy", 0.1f);

    }

    private void MissileDestroy() 
    {
        Destroy(gameObject);
    }
}
