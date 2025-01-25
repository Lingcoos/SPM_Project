using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;

    protected virtual void Start()
    {
        currentCooldown =cooldownDuration;
    }
    protected virtual void Update() 
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
            Attack();
    }
    protected virtual void Attack() 
    {
        currentCooldown = cooldownDuration;
    }
}
