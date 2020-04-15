using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class AudioPlayer : MonoBehaviour
{
  
  
    public StudioEventEmitter PlayerHurtMale;
    public StudioEventEmitter PlayerHurtFemale;
    public StudioEventEmitter Crowd;

    [EventRef]
    public string playerAttack;
    public FMOD.Studio.EventInstance playerAttacking;

    [EventRef]
    public string playerDash;
    public FMOD.Studio.EventInstance playerDashing;

    [EventRef]
    public string playerThrow;
    public FMOD.Studio.EventInstance playerThrowing;




    public void PlayerThrowing()
    {
        playerThrowing = RuntimeManager.CreateInstance(playerThrow);
        RuntimeManager.PlayOneShot(playerThrow, transform.position);
        playerThrowing.start();
    }

    public void PlayerDashing()
    {
        playerDashing = RuntimeManager.CreateInstance(playerDash);
        RuntimeManager.PlayOneShot(playerDash, transform.position);
        playerDashing.start();
    }

    public void PlayerAttacking()
    {
        playerAttacking = RuntimeManager.CreateInstance(playerAttack);
        RuntimeManager.PlayOneShot(playerAttack, transform.position);
        playerAttacking.start();
    }
}
