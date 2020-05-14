using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentatorIntroducingState : CommentatorAbstractClass
{
    // **** CONSTRUCTOR **** //
    public CommentatorIntroducingState(CommentatorStatePattern stateMachine)
    {
        base.p_commentator = stateMachine;
    }

    public override void Enter()
    {
        p_commentator.allowedToSpeak = true;
    }

    public override void Execute()
    {
        if (p_commentator.allowedToSpeak)
        {
            Debug.Log("HELLOOOO EVERYONE!!!"); //REPLACE THIS LINE WITH ACTUAL AUDIO FUNCTION! 
            p_commentator.audioCom.Intro();
            p_commentator.allowedToSpeak = false;
        }

        p_commentator.hiddenCooldownTimer += Time.deltaTime;

        if (p_commentator.hiddenCooldownTimer > p_commentator.silencePostIntro)
        {
            p_commentator.ChangeState(p_commentator.silentState);
        }

        if (p_commentator.deathComment && p_commentator.hiddenCooldownTimer > p_commentator.hardSilenceTimer)
        {
            p_commentator.ChangeState(p_commentator.speakingState);
        }

        if (p_commentator.victoryComment)
        {
            p_commentator.ChangeState(p_commentator.speakingState);
        }
    }

    public override void Exit()
    {
        p_commentator.hiddenCooldownTimer = 0.0f;
    }
}