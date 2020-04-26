using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : PlayerIState
{
    private readonly PlayerStatePattern player;
    public float internalStateTimer = 0f;

    public PlayerThrowState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }

    public void OnStateEnter()
    {
        player.animator.SetBool("Throw", true);
        player.ThrowItem();
    }

    public void UpdateState()
    {
        player.ChangeDirection();
        if (internalStateTimer >= player.throwAnimDuration)
        {
            ChangeState(player.idleState);
        }
        else
            internalStateTimer += Time.deltaTime;
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
            internalStateTimer = 0f;
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
