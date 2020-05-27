using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinState : PlayerIState
{
    private readonly PlayerStatePattern player;

    public PlayerWinState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }

    public void OnStateEnter()
    {
        player.transform.Rotate(0,-90,0);
        player.animator.SetBool("Win", true);
    }

    public void ChangeState(PlayerIState newState)
    {
        player.animator.SetBool("Win", false);
        player.StateChanger(newState);
    }

    public void TakeDamage(float damage)
    {
        //borde inte vara möjligt
    }

    public void UpdateState()
    {
        if (player.gameManager.gameState != player.gameManager.winState)
        {
            player.RunOrIdleDecider();
        }
    }
}
