using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IState
{
    private Enemy enemy;
    public EnemyAttackState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {

    }


    public void OnUpData()
    {

    }
    public void OnFixUpData()
    {

    }
    public void OnExit()
    {

    }

}
