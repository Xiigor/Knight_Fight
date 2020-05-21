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
        if(weapon.thisWepType == WeaponBaseClass.Weapontype.throwable)
        {
            if(weapon.attackActive == true)
            {
                movementApplied = true;
                Debug.Log("Attack");
            }
        }
        else
        {
            weapon.audioPlayer.WeaponBeingThrown();
            movementApplied = false;
            ChangePhysics();
            weapon.gameObject.tag = weapon.projectileTag;
            AddThrownForce();
            weapon.RemoveParentPlayer();
            Debug.Log("throw");
        }
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

    public void HandleCollision(Collision col)
    {
        // här kan man lägga in att olika ljud ska spelas baserat på föremål man träffar.
        if(col.gameObject.tag == weapon.environmentTag)
        {
            weapon.audioPlayer.ThrownWepHittingEnvironment();
        }
        if(col.gameObject.tag == weapon.playerTag)
        {
            weapon.audioPlayer.AttackHittingPlayer();
        }
    }

    public void AddThrownForce()
    {
        //Throw the weapon the way the player is facing
        throwVector = new Vector3(weapon.parentPlayer.transform.forward.x, weapon.throwAngle, weapon.parentPlayer.transform.forward.z);
        weapon.rb.velocity = throwVector * weapon.thrownForce;
        movementApplied = true;
    }
}