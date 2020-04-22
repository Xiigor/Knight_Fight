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

    }

    public void AttackHittingPlayer()
    {

    }

    public void WeaponBeingThrown()
    {

    }

    public void ThrownWepHittingEnvironment()
    {

    }

    public void WeaponBeingPickedUp()
    {

    }

    public void WeaponBreaking()
    {
        //detta scenarion existerar inte kodmässigt än.
    }



}
