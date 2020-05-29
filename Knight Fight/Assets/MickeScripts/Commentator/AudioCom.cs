﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioCom : MonoBehaviour
{
    [EventRef]
    public string onVictory;
    public FMOD.Studio.EventInstance onWin;

    [EventRef]
    public string bored;
    public FMOD.Studio.EventInstance boredDialogue;

    [EventRef]
    public string intro;
    public FMOD.Studio.EventInstance introduction;

    public void InterruptSpeech()
    {
        onWin.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        boredDialogue.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        introduction.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }


    public void OnWin()
    {
        InterruptSpeech();
        onWin = RuntimeManager.CreateInstance(onVictory);
        onWin.start();
    }

    public void Bored()
    {
        InterruptSpeech();
        boredDialogue = RuntimeManager.CreateInstance(bored);
        boredDialogue.start();
    }

    public void Intro()
    {
        InterruptSpeech();
        introduction = RuntimeManager.CreateInstance(intro);
        introduction.start();
    }
}
