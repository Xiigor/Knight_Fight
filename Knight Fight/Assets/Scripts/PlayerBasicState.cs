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
    public void ToBasicState()
    {
        Debug.Log("Already in state");
    }
    public void ToAttackState()
    {
        player.internalGCDTimer = 0.0f;
    }
    public void ToHitState()
    {

    }
    public void ToDashState()
    {

    }
    public void ToPickupState()
    {

    }
    public void ToDeadState()
    {

    }
}
