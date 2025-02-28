using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveStateOnline : IState
{
    private PlayerNetWrok player;
    public PlayerMoveStateOnline(PlayerNetWrok player)
    {
        this.player = player;
    }

    public void OnEnter()
    {
        player.ani.Play("Move");
    }


    public void OnUpData()
    {
        if (!player.isRuning)
            player.TransitionState(PlayerStateType.Idle);
    }
    public void OnFixUpData()
    {
       
    }
    public void OnExit()
    {

    }

}
