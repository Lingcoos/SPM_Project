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
        
    }


    public void OnUpData()
    {
        enemy.ChasePlayer();
        if (enemy.isHurt) 
        {
            enemy.TransitionState(EnemyStateType.Hurt);
        }
        if (enemy.isDie && !enemy.isHurt) 
        {
            enemy.TransitionState(EnemyStateType.Die);
        }
    }
    public void OnFixUpData()
    {
       
    }
    public void OnExit()
    {

    }

}
