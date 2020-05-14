using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentatorSilentState : CommentatorAbstractClass
{
    // **** CONSTRUCTOR **** //
    public CommentatorSilentState(CommentatorStatePattern stateMachine)
    {
        base.p_commentator = stateMachine;
    }

    public override void Enter()
    {
        p_commentator.allowedToSpeak = false;
    }

    public override void Execute()
    {
        if (!p_commentator.allowedToSpeak)
        {
            Debug.Log("Silent State");
            p_commentator.hiddenCooldownTimer += Time.deltaTime;
        }

        if (p_commentator.hiddenCooldownTimer > p_commentator.speakingCooldown)
        {
            p_commentator.boredComment = true;
            p_commentator.ChangeState(p_commentator.speakingState);
        }

        if (p_commentator.deathComment)
        {
            p_commentator.boredComment = false;
            p_commentator.ChangeState(p_commentator.speakingState);
        }

        if (p_commentator.victoryComment)
        {
            p_commentator.boredComment = false;
            p_commentator.ChangeState(p_commentator.speakingState);
        }
    }

    public override void Exit()
    {
        p_commentator.hiddenCooldownTimer = 0.0f;
    }
}