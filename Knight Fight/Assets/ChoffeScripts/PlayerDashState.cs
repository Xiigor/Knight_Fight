using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerIState
{
    private readonly PlayerStatePattern player;
    private float internalStateTimer;

    public PlayerDashState(PlayerStatePattern statePatternPlayer)
    {
        player = statePatternPlayer;
    }

    public void OnStateEnter()
    {
        player.animator.SetBool("Dash", true);
        if (player.weapon != null)
        {
            player.weapon.GetComponent<Collider>().enabled = true;
        }
    }

    public void UpdateState()
    {
        internalStateTimer += Time.deltaTime;
        if (player.canDash)
        {
            if(internalStateTimer < player.dashDuration)
            {
                player.Dash();
            }
            else
            {
                ChangeState(player.basicState);
            }
        }
        else
        {
            ChangeState(player.basicState);
        }
    }
    public void ChangeState(PlayerIState newState)
    {
        if (newState == player.basicState || newState == player.idleState)
        {
            player.animator.SetBool("Dash", false);
            internalStateTimer = 0f;
            player.internalDashTimer = 0f;
            player.internalGCDTimer = 0f;

            if(player.weapon != null)
            {
                player.weapon.GetComponent<Collider>().enabled = false;
            }

            player.StateChanger(newState);
        }
        else
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
