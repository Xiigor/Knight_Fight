using FMODUnity;
using System;
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
        float closestDistance = Mathf.Infinity;
        GameObject closestCrowd = null;
        for (int i = 0; i < player.crowdParent.childCount; i++)
        {
            Transform crowd = player.crowdParent.GetChild(i);
            float distance = Vector3.Distance(player.transform.position, crowd.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCrowd = crowd.gameObject;
            }

        }

        closestCrowd.GetComponent<AudioCrowd>().Cheer();
        
        //Förmodligen loppa crowd här så att dem jublar

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
    public void TakeDamage(float damage)
    {
        //cant be dealt more damage
    }
}
