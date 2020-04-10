using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrownState : WeaponIState
{
    private readonly WeaponBaseClass weapon;
    private Vector3 throwVector;
    private bool movementApplied = false;

    public WeaponThrownState(WeaponBaseClass weaponBase)
    {
        weapon = weaponBase;
    }

    public void OnStateEnter()
    {
        movementApplied = false;
        ChangePhysics();
        weapon.gameObject.tag = weapon.projectileTag;
        weapon.damageZoneObject.SetActive(false);
        AddThrownForce();
        weapon.RemoveParentPlayer();
    }
    public void UpdateState()
    {
        if(movementApplied == true)
        {
            if (weapon.rb.velocity == Vector3.zero)
            {
                weapon.ChangeState(weapon.unequippedState);
            }
        }
    }
    public void ChangePhysics()
    {
        weapon.rb.isKinematic = false;
        weapon.col.enabled = true;
        weapon.rb.useGravity = true;
    }

    public void ChangeState(WeaponIState newState)
    {
       if(newState == weapon.unequippedState)
        {
            weapon.currentState = newState;
        }
    }

    public void HandleCollision(Collision col)
    {
        Debug.Log(weapon.gameObject.name + " Hits " + col.gameObject.name);
    }

    public void AddThrownForce()
    {
        //Throw the weapon the way the player is facing
        throwVector = new Vector3(weapon.parentPlayer.transform.forward.x, weapon.throwAngle, weapon.parentPlayer.transform.forward.z);
        weapon.rb.velocity += throwVector * weapon.thrownForce;
        movementApplied = true;
    }
}