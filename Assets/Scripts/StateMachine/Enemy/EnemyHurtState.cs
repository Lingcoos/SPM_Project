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
