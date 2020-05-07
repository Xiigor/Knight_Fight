using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioWeapon : MonoBehaviour
{
    [EventRef]
    public string attack;
    public FMOD.Studio.EventInstance attacking;

    [EventRef]
    public string attackHitPlayer;
    public FMOD.Studio.EventInstance attackHittingPlayer;

    [EventRef]
    public string throwWep;
    public FMOD.Studio.EventInstance weaponBeingThrown;

    [EventRef]
    public string ThrownWepHitEnvironment;
    public FMOD.Studio.EventInstance thrownWepHittingEnvironment;

    [EventRef]
    public string weaponPickup;
    public FMOD.Studio.EventInstance weaponBeingPickedUp;

    [EventRef]
    public string weaponBreak;
    public FMOD.Studio.EventInstance weaponBreaking;

    public void Attacking()
    {
        RuntimeManager.PlayOneShot(attack, transform.position);
    }

    public void AttackHittingPlayer()
    {
        RuntimeManager.PlayOneShot(attackHitPlayer, transform.position);
    }

    public void WeaponBeingThrown()
    {
        RuntimeManager.PlayOneShot(throwWep, transform.position);
    }

    public void ThrownWepHittingEnvironment()
    {
        RuntimeManager.PlayOneShot(ThrownWepHitEnvironment, transform.position);
    }

    public void WeaponBeingPickedUp()
    {
        RuntimeManager.PlayOneShot(weaponPickup, transform.position);
    }

    public void WeaponBreaking()
    {
        //detta scenarion existerar inte kodmässigt än.
    }



}
