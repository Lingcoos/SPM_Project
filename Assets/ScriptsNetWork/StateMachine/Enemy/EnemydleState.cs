using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleStateOnline : IState
{
    private EnemyNetWork enemy;
    public EnemyIdleStateOnline(EnemyNetWork enemy)
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
