using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerIState
{
    private readonly PlayerStatePattern player;
    public float internalStateTimer = 0f;

    public PlayerAttackState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }

    public void UpdateState()
    {
        player.Attack();
        if (internalStateTimer >= player.attackAnimDuration)
        {
            ChangeState(player.basicState);
        }
        else
            internalStateTimer += Time.deltaTime;
        
    }
    public void ChangeState(PlayerIState newState)
    {
        internalStateTimer = 0f;
        if (newState == player.basicState)
        {
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
