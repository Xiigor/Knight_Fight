using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrownState : WeaponIState
{
    private readonly WeaponBaseClass weapon;

    public WeaponThrownState(WeaponBaseClass weaponBase)
    {
        weapon = weaponBase;
    }

    public void OnStateEnter()
    {
        weapon.RemoveParentPlayer();
        ChangePhysics();
        AddThrownForce();
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
        if(col.gameObject.tag == weapon.playerTag)
        {
            if(col.gameObject == weapon.parentPlayer)
            {
                //Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), weapon.col);
            }
            //if (col.gameObject != weapon.parentPlayer)
            else
            {
                col.gameObject.GetComponent<PlayerStatePattern>().OnHit(weapon.thrownDamage);
            }
        }
        else
        {
            ChangeState(weapon.unequippedState);
        }
    }
    public void AddThrownForce()
    {
        //Throw the weapon the way the player is facing
        //weapon.rb.AddForce(weapon.parentPlayer.transform.up * weapon.thrownForce);
        weapon.rb.velocity += weapon.parentPlayer.transform.forward * weapon.thrownForce;
    }

}