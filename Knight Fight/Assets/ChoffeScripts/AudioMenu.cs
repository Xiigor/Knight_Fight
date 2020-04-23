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
        buttonPressed = RuntimeManager.CreateInstance(buttonPress);
        RuntimeManager.PlayOneShot(buttonPress, transform.position);
        buttonPressed.start();
    }

    public void StartPressed()
    {
        startPressed = RuntimeManager.CreateInstance(startPress);
        RuntimeManager.PlayOneShot(startPress, transform.position);
        startPressed.start();
    }

    public void PlayerJoined()
    {
        playerJoined = RuntimeManager.CreateInstance(playerJoin);
        RuntimeManager.PlayOneShot(playerJoin, transform.position);
        playerJoined.start();
    }

    public void PlayerLeft()
    {
        playernotRight = RuntimeManager.CreateInstance(playerLeft);
        RuntimeManager.PlayOneShot(playerLeft, transform.position);
        playernotRight.start();
    }

    public void StartMenuMusic()
    {
        menuModeMusic = RuntimeManager.CreateInstance(menuMusic);
        RuntimeManager.PlayOneShot(menuMusic, transform.position);
        menuModeMusic.start();
    }

    public void StartGameplayMusic()
    {
        gameplayModeMusic = RuntimeManager.CreateInstance(gameplayMusic);
        RuntimeManager.PlayOneShot(gameplayMusic, transform.position);
        gameplayModeMusic.start();
    }

}
