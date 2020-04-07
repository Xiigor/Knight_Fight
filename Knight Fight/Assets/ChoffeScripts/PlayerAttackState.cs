using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerIState
{
    private readonly PlayerStatePattern player;
    public float internalStateTimer;

    public PlayerAttackState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }

    public void UpdateState()
    {
        //player.Attack();
        ChangeState(player.basicState);
    }
    public void ChangeState(PlayerIState newState)
    {
        if (newState == player.basicState)
        {
            player.currentState = newState;
        }
        else
            Debug.Log("GCD Trigger");
    }

    public void TakeDamage(WeaponBase weapon)
    {
        //player.health -= weapon.damage;
    }
}
