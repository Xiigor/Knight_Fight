using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerIState
{
    private readonly PlayerStatePattern player;
    private float internalStateTimer;

    public PlayerDashState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }
    public void UpdateState()
    {
        internalStateTimer += Time.deltaTime;
        if (player.canDash)
        {
            if(internalStateTimer < player.dashDuration)
            {
                player.Dash();
            }
            else
            {
                ChangeState(player.basicState);
            }
        }
        else
        {
            ChangeState(player.basicState);
        }
    }
    public void ChangeState(PlayerIState newState)
    {
        if (newState == player.basicState)
        {
            internalStateTimer = 0f;
            player.internalDashTimer = 0f;
            player.internalGCDTimer = 0f;
            player.currentState = newState;
        }
        else
            Debug.Log("GCD Trigger");
    }

}
