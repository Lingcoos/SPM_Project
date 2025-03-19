using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : IState
{
    private Enemy enemy;
    public EnemyHurtState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        enemy.FlashColor(0.1f);
        
    }
    public void OnUpData()
    {
        if (enemy.isDie&& enemy.isHurt) 
        {
            enemy.TransitionState(EnemyStateType.Die);
        }
        if (!enemy.isHurt) 
        {
            enemy.TransitionState(EnemyStateType.Move);
        }
        
    }
    public void OnFixUpData()
    {
       
    }
    public void OnExit()
    {
        
    }

}
