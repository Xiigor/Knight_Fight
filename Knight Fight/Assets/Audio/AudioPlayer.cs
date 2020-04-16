using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class AudioPlayer : MonoBehaviour
{




    [EventRef]
    public string playerHurt;
    public FMOD.Studio.EventInstance playerHurting;

    [EventRef]
    public string playerHurtMale;
    public FMOD.Studio.EventInstance playerHurtingMale;

    [EventRef]
    public string playerHurtFemale;
    public FMOD.Studio.EventInstance playerHurtingFemale;

    [EventRef]
    public string playerAttack;
    public FMOD.Studio.EventInstance playerAttacking;

    [EventRef]
    public string playerDash;
    public FMOD.Studio.EventInstance playerDashing;

    [EventRef]
    public string playerThrow;
    public FMOD.Studio.EventInstance playerThrowing;

    [EventRef]
    public string playerThrowMale;
    public FMOD.Studio.EventInstance playerThrowingMale;



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
    public void PlayerHurting() //Spelar alla vapenljud för female
    {
        playerHurting = RuntimeManager.CreateInstance(playerHurt);
        RuntimeManager.PlayOneShot(playerHurt, transform.position);
        playerHurting.start();
    }
    public void PlayerHurtingMale() //Spelar alla vapenljud för male
    {
        playerHurtingMale = RuntimeManager.CreateInstance(playerHurtMale);
        RuntimeManager.PlayOneShot(playerHurtMale, transform.position);
        playerHurtingMale.start();
    }
    public void PlayerHurtingFemale() //Spelar alla vapenljud för female
    {
        playerHurtingMale = RuntimeManager.CreateInstance(playerHurtFemale);
        RuntimeManager.PlayOneShot(playerHurtFemale, transform.position);
        playerHurtingFemale.start();
    }
}
