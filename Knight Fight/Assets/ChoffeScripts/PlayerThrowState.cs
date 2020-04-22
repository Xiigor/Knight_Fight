using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : PlayerIState
{
    private readonly PlayerStatePattern player;

    public PlayerThrowState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }
    public void UpdateState()
    {
        player.ThrowItem();
        ChangeState(player.basicState);
    }
    public void ChangeState(PlayerIState newState)
    {
        if(newState == player.deadState)
        {
            player.currentState = newState;
        }
        else if (newState == player.basicState)
        {
            player.internalGCDTimer = 0f;
            player.currentState = newState;
        }
        else
            Debug.Log("GCD Trigger");
    }
    public void TakeDamage(float damage)
    {
        player.health -= damage;
    }
}
