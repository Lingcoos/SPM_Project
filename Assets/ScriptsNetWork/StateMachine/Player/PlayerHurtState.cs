using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtStateOnline : IState
{
    private PlayerNetWrok player;
    public PlayerHurtStateOnline(PlayerNetWrok player)
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
