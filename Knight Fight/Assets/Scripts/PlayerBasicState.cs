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
    public void UpdateState()
    {
        player.Movement();

    }
    public void ChangeState(PlayerIState newState)
    {
        if (player.ValidStateChange(newState))
        {
            player.currentState = newState;
        }
    }
}
