using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : IState
{
    private Player player;
    public PlayerDieState(Player player)
    {
        this.player = player;
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
