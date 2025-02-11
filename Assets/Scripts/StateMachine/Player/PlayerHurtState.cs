using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : IState
{
    private Player player;
    public PlayerHurtState(Player player)
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
