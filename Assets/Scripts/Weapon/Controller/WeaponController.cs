using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    [HideInInspector]public int level;
    public GameObject prefab;
    public float damage;
    public int count;
    public float speed;
    public float turnSpeed;
    public float timer;
    public float cooldownDuration;
    float currentCooldown;

    public string[] levelUpDescrible;
    [HideInInspector]public Weapon weapon;

    protected virtual void Start()
    {
        currentCooldown =cooldownDuration;
        weapon = GetComponent<Weapon>();
    }
    protected virtual void Update() 
    {
        weapon.weaponLevel = level;
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
            Attack();
    }
    protected virtual void Refresh() 
    {
        
    }
    protected virtual void Attack() 
    {
        currentCooldown = cooldownDuration;
    }
    protected virtual void OnEnable()
    {
        level++;
    }
  
    
}
