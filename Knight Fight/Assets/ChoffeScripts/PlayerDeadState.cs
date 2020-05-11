using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerIState
{

    private readonly PlayerStatePattern player;
    public float internalStateTimer;

    public PlayerDeadState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }

    public void OnStateEnter()
    {
        player.gameManager.alivePlayers.Remove(player.gameObject);
        player.EnableRagdoll();
        player.tag = player.deadPlayerTag;
    }

    public void UpdateState()
    {

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
    public void TakeDamage(float damage)
    {
        //cant be dealt more damage
    }
}
