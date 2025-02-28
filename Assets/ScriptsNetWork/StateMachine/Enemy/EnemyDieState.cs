using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieStateOnline : IState
{
    private EnemyNetWork enemy;
    public EnemyDieStateOnline(EnemyNetWork enemy)
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
