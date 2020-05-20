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
        player.cameraScript.objectsFollowedByCamera.Remove(player.gameObject);
        player.gameManager.alivePlayers.Remove(player.gameObject);
        player.EnableRagdoll();
        player.tag = player.deadPlayerTag;
        float closestDistance = Mathf.Infinity;
        GameObject closestCrowd = null;

        if (player.cameraScript.objectsFollowedByCamera.Count > 1)
        {
            player.commentatorScript.deathTrigger = true;
        }

        for(int i = 0; i < player.crowdParent.childCount; i++)
        {
            Transform crowd = player.crowdParent.GetChild(i);
            float distance = Vector3.Distance(player.transform.position, crowd.position);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestCrowd = crowd.gameObject;
            }
        }
        closestCrowd.GetComponent<AudioCrowd>().Cheer();
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
