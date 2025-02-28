using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieStateOnline : IState
{
    private PlayerNetWrok player;
    public PlayerDieStateOnline(PlayerNetWrok player)
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
