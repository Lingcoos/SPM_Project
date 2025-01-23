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
