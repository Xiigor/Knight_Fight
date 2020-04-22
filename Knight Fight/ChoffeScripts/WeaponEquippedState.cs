﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquippedState : WeaponIState
{
    private readonly WeaponBaseClass weapon;

    public WeaponEquippedState(WeaponBaseClass weaponBase)
    {
        weapon = weaponBase;
    }

    public void OnStateEnter()
    {
<<<<<<< HEAD
=======
        
        weapon.audioPlayer.WeaponBeingPickedUp();
        weapon.gameObject.layer = weapon.EquippedLayer;
>>>>>>> Progg-Choffe
        ChangePhysics();
        weapon.HeldPos();
    }
    public void UpdateState()
    {

    }

    public void ChangePhysics()
    {
        weapon.rb.isKinematic = true;
        weapon.col.enabled = false;
        weapon.rb.useGravity = false;
    }

    public void HandleCollision(Collision col)
    {
        // this state ignores all collisions
    }
}
