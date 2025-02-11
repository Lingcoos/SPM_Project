using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : IState
{
    private Enemy enemy;
    public EnemyIdleState(Enemy enemy)
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
