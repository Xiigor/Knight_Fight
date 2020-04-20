using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerIState
{
    private readonly PlayerStatePattern player;

    public PlayerIdleState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }

    public void ChangeState(PlayerIState newState)
    {
        if (newState == player.deadState)
        {
            player.currentState = newState;
        }

        else if (newState == player.basicState)
        {
            player.currentState = newState;
        }

        else if (player.ValidStateChange(newState))
        {
            player.currentState = newState;
        }
    }

    public void UpdateState()
    {
        player.ChangeDirection();
        if (player.moveDir != Vector2.zero)
        {
            ChangeState(player.basicState);
        }
    }

    public void TakeDamage(float damage)
    {
        player.health -= damage;
    }
}
