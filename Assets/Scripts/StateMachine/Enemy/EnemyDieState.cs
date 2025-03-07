using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : IState
{
    private Enemy enemy;
    public EnemyDieState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        enemy.EnemyDestroy();
    }


    public void OnUpData()
    {
        if (!enemy.isDie) 
        {
            enemy.TransitionState(EnemyStateType.Move);
        }
    }
    public void OnFixUpData()
    {
       
    }
    public void OnExit()
    {
        enemy.isDie = false;
    }

}
