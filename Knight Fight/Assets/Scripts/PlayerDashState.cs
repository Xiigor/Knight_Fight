using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerIState
{
    private readonly PlayerStatePattern player;

    public PlayerDashState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }
    public void UpdateState()
    {
        player.Movement();

    }
    public void ToBasicState()
    {

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
        Debug.Log("Already in state");
    }
    public void ToPickupState()
    {

    }
    public void ToDeadState()
    {

    }
}
