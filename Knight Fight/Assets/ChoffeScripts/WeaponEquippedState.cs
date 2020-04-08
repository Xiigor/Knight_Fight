using System.Collections;
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
        ChangePhysics();
        weapon.HeldPos();
    }

    public void ChangePhysics()
    {
        weapon.rb.isKinematic = true;
        weapon.col.enabled = false;
        weapon.rb.useGravity = false;
    }

    public void ChangeState(WeaponIState newState)
    {
        if(newState == weapon.thrownState)
        {
            weapon.currentState = newState;
        }
    }

    public void HandleCollision(Collision col)
    {
        // this state ignores all collisions
    }
}
