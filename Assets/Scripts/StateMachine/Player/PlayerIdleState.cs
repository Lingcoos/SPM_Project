using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    private Player player;
    public PlayerIdleState(Player player)
    {
        this.player = player;
    }

    public void OnEnter()
    {
        player.ani.Play("Idle");
    }


    public void OnUpData()
    {
        if (player.isRuning) 
        {
            player.TransitionState(PlayerStateType.Move);
        }

    }
    public void OnFixUpData()
    {
       
    }
    public void OnExit()
    {

    }

}
