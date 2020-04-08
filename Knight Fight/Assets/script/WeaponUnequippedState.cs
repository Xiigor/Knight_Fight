using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUnequippedState : WeaponIState
{
    private readonly WeaponBaseClass weapon;

    public WeaponUnequippedState(WeaponBaseClass weaponBase)
    {
        weapon = weaponBase;
    }

    public void OnStateEnter()
    {
        ChangePhysics();
        //Physics.IgnoreCollision(weapon.parentPlayer.col, weapon.col, false);
        weapon.parentPlayer = null;
        //weapon.RemoveParentPlayer();
    }

    public void ChangePhysics()
    {
        weapon.rb.isKinematic = false;
        weapon.col.enabled = true;
        weapon.rb.useGravity = true;
    }

    public void ChangeState(WeaponIState newState)
    {
        if(newState == weapon.equippedState)
        {
            weapon.currentState = newState;
        }
        else
        {
            Debug.Log("Invalid state change from Unequipped");
        }
    }

    public void HandleCollision(Collision col)
    {
       if(col.gameObject.tag == weapon.playerTag)
        {
            //if the player is not holding a weapon already, pick up this one
            if(col.gameObject.GetComponent<PlayerStatePattern>().weapon == null)
            {
                weapon.SetParentPlayer(col);
                col.gameObject.GetComponent<PlayerStatePattern>().weapon = weapon.gameObject;
                //Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), weapon.col, true);
                ChangeState(weapon.equippedState);
               
            }
        }
    }
}
