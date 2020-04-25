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

    public void OnStateEnter()
    {
        player.animator.SetBool("Throw", true);
    }

    public void UpdateState()
    {
        player.ThrowItem();
        ChangeState(player.basicState);
    }
    public void ChangeState(PlayerIState newState)
    {
        player.animator.SetBool("Throw", false);
        if (newState == player.deadState)
        {
            player.StateChanger(newState);
        }
        else if (newState == player.basicState || newState == player.idleState)
        {
            player.internalGCDTimer = 0f;
            player.StateChanger(newState);
        }
        else
            Debug.Log("GCD Trigger");
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
