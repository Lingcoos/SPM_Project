using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtStateOnline : IState
{
    private EnemyNetWork enemy;
    public EnemyHurtStateOnline(EnemyNetWork enemy)
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
