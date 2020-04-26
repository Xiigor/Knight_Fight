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

    public void OnStateEnter()
    {
        player.animator.SetBool("Idle", true);
    }

    public void ChangeState(PlayerIState newState)
    {
        player.animator.SetBool("Idle", false);
        if (newState == player.deadState)
        {
            player.StateChanger(newState);
        }

        else if (newState == player.basicState)
        {
            player.StateChanger(newState);
        }

        else if (player.ValidStateChange(newState))
        {
            player.StateChanger(newState);
        }
    }

    public void UpdateState()
    {
        player.animator.SetBool("Idle", true);
        player.ChangeDirection();
        if (player.moveDir != Vector2.zero)
        {
            ChangeState(player.basicState);
        }
    }

    public void TakeDamage(float damage)
    {
        player.health -= damage;
        if (player.health <= 0)
        {
            player.Die();
        }
    }
}
