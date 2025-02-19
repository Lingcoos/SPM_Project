using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;

public class SwordController : WeaponController
{
    public Vector3 offset;
    private Transform sword;
    public Vector3 target;
    public bool isRotating = true;

    [SerializeField]private List<Transform> swords = new List<Transform>(); 
    [SerializeField]private List<Transform> enemies = new List<Transform>(); 
    [SerializeField] private List<Transform> availableTargets = new List<Transform>(); 

    protected override void Start()
    {
        Refresh();
    }
    protected override void Refresh()
    {
        base.Start();
        for (int i = 0; i < count; i++)
        {
            SwordGenerator();
        }
        UpdateEnemyList();

    }
    protected override void Attack()
    {


    }
    protected override void Update()
    {
        base.Update();
        UpdateEnemyList();
        for (int i = 0; i < count; i++) 
        {
            Transform sword =swords[i];
            Transform target = sword.GetComponent<Sword>().enemy;
            if (target == null)
            {
                AssignTarget(sword);
            }
            else
            {
                RotationSword(sword,target);
                MoveObject(sword, target);
            }
        }

    }
    private void AssignTarget(Transform sword)
    {
        if (availableTargets.Count > 0) 
        {
            Transform target = availableTargets[0];
            sword.GetComponent<Sword>().enemy = target;
            availableTargets.Remove(target);
        }
    }
    public void UpdateEnemyList() //更新敌人列表
    {
        Enemy[] enemyArray = FindObjectsOfType<Enemy>();

        enemies.Clear();
        availableTargets.Clear();
        foreach (Enemy enemy in enemyArray)
        {
            enemies.Add(enemy.transform);
            availableTargets.Add(enemy.transform);
        }
        for (int i = enemies.Count - 1; i >= 0; i--) 
        {
            if (enemies[i] == null) 
            {
                enemies.RemoveAt(i);
                availableTargets.RemoveAt(i);
            }
        }
    }
    public void MoveObject(Transform sword,Transform target)
    {

        sword.position = Vector3.MoveTowards(sword.position, target.position, speed * Time.deltaTime);
    }
    public void RotationSword(Transform sword,Transform target)
    {

        Vector2 dir = sword.position - target.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle + 45f);
        sword.rotation = Quaternion.RotateTowards(sword.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }
    public void SwordGenerator()
    {
        sword = Instantiate(prefab, transform.position + offset, prefab.transform.rotation).transform;
        swords.Add(sword);

    }
    public void levelUp()
    {
        switch (level)
        {
            case 0:
                level++;
                break;
            case 1:
                level++;
                break;
            case 2:
                count += 2;
                level++;
                break;
            case 3:
                level++;
                break;
            case 4:
                count += 2;
                level++;
                break;
            case 5:
                GetComponent<Weapon>().isLevelMax = true;
                WeaponSelectController.instance.LevelMaxRemove("Sword");
                weapon.weaponLevel++;
                break;
        }
        for (int i = 0; i < swords.Count; i++)
        {
            Destroy(swords[i].gameObject);
         }
            swords.Clear();
        Refresh();

    }
}

