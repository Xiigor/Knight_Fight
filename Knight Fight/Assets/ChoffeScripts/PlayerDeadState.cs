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
    public void UpdateState()
    {
        //Ded :(
        //Ragdoll function
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
        //cant be dealt more damage
    }
}
