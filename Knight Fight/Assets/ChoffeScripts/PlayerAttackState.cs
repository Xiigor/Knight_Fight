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

    public void OnStateEnter()
    {
        player.animator.SetBool("Attack", true);
        player.Attack();
    }


    public void UpdateState()
    {
        player.ChangeDirection();
        if (internalStateTimer >= player.attackAnimDuration)
        {
            player.RunOrIdleDecider();
        }
        else
            internalStateTimer += Time.deltaTime;
        
    }

    public void ChangeState(PlayerIState newState)
    {
        player.animator.SetBool("Attack", false);
        internalStateTimer = 0f;
        player.internalGCDTimer = 0f;
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
