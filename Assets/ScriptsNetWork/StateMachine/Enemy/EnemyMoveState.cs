using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveStateOnline : IState
{
    private EnemyNetWork enemy;
    public EnemyMoveStateOnline(EnemyNetWork enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        enemy.ani.Play("Move");
    }


    public void OnUpData()
    {
        enemy.ChasePlayer();
    }
    public void OnFixUpData()
    {
       
    }
    public void OnExit()
    {

    }

}
