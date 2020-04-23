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
        attacking = RuntimeManager.CreateInstance(attack);
        RuntimeManager.PlayOneShot(attack, transform.position);
        attacking.start();
    }

    public void AttackHittingPlayer()
    {
        attackHittingPlayer = RuntimeManager.CreateInstance(attackHitPlayer);
        RuntimeManager.PlayOneShot(attackHitPlayer, transform.position);
        attackHittingPlayer.start();
    }

    public void WeaponBeingThrown()
    {
        weaponBeingThrown = RuntimeManager.CreateInstance(throwWep);
        RuntimeManager.PlayOneShot(throwWep, transform.position);
        weaponBeingThrown.start();
    }

    public void ThrownWepHittingEnvironment()
    {
        thrownWepHittingEnvironment = RuntimeManager.CreateInstance(ThrownWepHitEnvironment);
        RuntimeManager.PlayOneShot(ThrownWepHitEnvironment, transform.position);
        thrownWepHittingEnvironment.start();
    }

    public void WeaponBeingPickedUp()
    {
        weaponBeingPickedUp = RuntimeManager.CreateInstance(weaponPickup);
        RuntimeManager.PlayOneShot(weaponPickup, transform.position);
        weaponBeingPickedUp.start();
    }

    public void WeaponBreaking()
    {
        //detta scenarion existerar inte kodmässigt än.
    }



}
