﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentatorSpeakingState : CommentatorAbstractClass
{
    // **** CONSTRUCTOR **** //
    public CommentatorSpeakingState(CommentatorStatePattern stateMachine)
    {
        base.p_commentator = stateMachine;
    }

    public override void Enter()
    {
        p_commentator.allowedToSpeak = true;
    }

    public override void Execute()
    {
        if (p_commentator.boredTrigger)
        {
            Debug.Log("ANYTHING GOING ON YO?!"); //REPLACE WITH AN ACTUAL AUDIO FUNCTION!!!

            p_commentator.audioCom.Bored();

            p_commentator.boredTrigger = false;
            p_commentator.allowedToSpeak = false;

            p_commentator.ChangeState(p_commentator.silentState);
        }

        if (p_commentator.deathTrigger)
        {
            Debug.Log("PLAYER HAS DIED!!"); //REPLACE WITH ACTUAL AUDIO FUNCTION!!!
            p_commentator.deathTrigger = false;
            p_commentator.allowedToSpeak = false;

            p_commentator.ChangeState(p_commentator.silentState);
        }

        if (p_commentator.victoryTrigger)
        {
            Debug.Log("VICTORY!!!"); //REPLACE WITH ACTUAL AUDIO FUNCTION!!!

            p_commentator.audioCom.OnWin();

            p_commentator.victoryTrigger = false;
            p_commentator.allowedToSpeak = false;

            p_commentator.ChangeState(p_commentator.inactiveState);
        }
    }

    public override void Exit()
    {
        p_commentator.hardSilenceTimer = 0.0f;
        p_commentator.hiddenCooldownTimer = 0.0f;
    }
}