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
        player.animator.SetBool("Running", false);
        player.animator.SetBool("Idle", true);
        
    }

    public void UpdateState()
    {
        player.ChangeDirection();
        if (player.moveDir != Vector2.zero)
        {
            ChangeState(player.basicState);
        }
    }

    public void ChangeState(PlayerIState newState)
    {
        player.animator.SetBool("Idle", false);
        player.StateChanger(newState);
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
