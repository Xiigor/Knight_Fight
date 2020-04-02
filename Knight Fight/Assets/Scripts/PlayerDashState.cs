using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerIState
{
    private readonly PlayerStatePattern player;
    public float internalStateTimer;

    public PlayerDashState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }
    public void UpdateState()
    {
        player.Dash();
        ChangeState(player.basicState);
    }
    public void ChangeState(PlayerIState newState)
    {
        if (newState == player.basicState)
        {
            player.currentState = newState;
        }
        else
            Debug.Log("GCD Trigger");
    }

}
