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
        player.animator.SetBool("Idle", false);
        player.animator.SetBool("Running", true);
        
    }

    public void UpdateState()
    {
        player.ChangeDirection();
        player.Movement();
        if(player.moveDir == Vector2.zero)
        {
            ChangeState(player.idleState);
        }
    }
    public void ChangeState(PlayerIState newState)
    {
        player.animator.SetBool("Running", false);
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
