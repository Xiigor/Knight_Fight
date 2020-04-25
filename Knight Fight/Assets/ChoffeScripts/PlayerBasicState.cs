using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicState : PlayerIState
{
    private readonly PlayerStatePattern player;

    public PlayerBasicState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }

    public void OnStateEnter()
    {
        player.animator.SetBool("Running", true);
    }

    public void UpdateState()
    {
        player.ChangeDirection();
        player.Movement();
        if (player.moveDir == Vector2.zero)
        {
            ChangeState(player.idleState);
        }

    }
    public void ChangeState(PlayerIState newState)
    {
        player.animator.SetBool("Running", false);
        if (newState == player.deadState)
        {
            player.StateChanger(newState);
        }

        else if (newState == player.idleState)
        {
            player.StateChanger(newState);
        }

        else if (player.ValidStateChange(newState))
        {
            player.StateChanger(newState);
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
