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
        Debug.Log("hur ofta händer detta?");
        
    }


    public void UpdateState()
    {
        player.ChangeDirection();
        if (internalStateTimer >= player.attackAnimDuration)
        {
            player.Attack();
            ChangeState(player.idleState);
        }
        else
            internalStateTimer += Time.deltaTime;
        
    }


    public void UpdateState()
    {
        if (newState == player.basicState || newState == player.idleState)
        {

            player.internalGCDTimer = 0f;
            internalStateTimer = 0f;
            player.animator.SetBool("Attack", false);
            player.StateChanger(newState);
        }
        else
        {
            ChangeState(player.idleState);
        }
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
