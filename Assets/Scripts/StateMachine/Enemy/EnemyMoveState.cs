using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : IState
{
    private Enemy enemy;
    public EnemyMoveState(Enemy enemy)
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
