using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioMenu : MonoBehaviour
{
    [EventRef]
    public string buttonPress;
    public FMOD.Studio.EventInstance buttonPressed;

    [EventRef]
    public string startPress;
    public FMOD.Studio.EventInstance startPressed;

    [EventRef]
    public string playerJoin;
    public FMOD.Studio.EventInstance playerJoined;

    [EventRef]
    public string playerLeft;
    public FMOD.Studio.EventInstance playernotRight;

    [EventRef]
    public string menuMusic;
    public FMOD.Studio.EventInstance menuModeMusic;

    [EventRef]
    public string gameplayMusic;
    public FMOD.Studio.EventInstance gameplayModeMusic;



    public void ButtonPressed()
    {

    }

    public void StartPressed()
    {

    }

    public void PlayerJoined()
    {

    }

    public void PlayerLeft()
    {

    }

    public void StartMenuMusic()
    {

    }

    public void StartGameplayMusic()
    {

    }

}
