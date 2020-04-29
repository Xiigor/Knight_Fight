using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class WeaponBaseClass : MonoBehaviour
{
    public GameObject parentPlayer = null;
    public AudioWeapon audioPlayer;

    public WeaponIState currentState;
    [HideInInspector] public WeaponUnequippedState unequippedState;
    [HideInInspector] public WeaponEquippedState equippedState;
    [HideInInspector] public WeaponThrownState thrownState;
    public enum Weapontype{ oneHSword, twoHSword, spellbook };
    public Weapontype thisWepType;
    
    public float durability;
    public float damage;
    public float thrownDamage;
    public float thrownForce;
    public float throwAngle;

    public string environmentTag = "Environment";
    public string playerTag = "Player";
    public string projectileTag = "WeaponProjectile";
    public string weaponTag = "Weapon";

    public int UnequippedLayer = 13;
    public int EquippedLayer = 14;

    public Vector3 heldPosition;
    public Vector3 heldRotation;
    public Rigidbody rb;
    public Collider col;
    [HideInInspector] public Animator anim;

    public abstract void Attack();
    public void ThrowWep()
    {
        ChangeState(thrownState);
    }
    public abstract void ChangeDurability(float durabilityDecrement);

    public void HeldPos()
    {
        transform.localPosition = heldPosition;
        transform.localEulerAngles = heldRotation;
    }

    public void BreakWeapon()
    {
        //destroy the weapon and all traces of it
    }


    public void SetParentPlayer(Collision collision)
    {


        parentPlayer = collision.gameObject;
        if(thisWepType == Weapontype.spellbook)
        {
            transform.SetParent(collision.gameObject.GetComponent<PlayerStatePattern>().leftHandGameobject.transform);
        }
        else
        {
            transform.SetParent(collision.gameObject.GetComponent<PlayerStatePattern>().rightHandGameobject.transform);
        }
    }
    public void RemoveParentPlayer()
    {
        transform.parent = null;
    }
    public abstract void OnCollisionEnter(Collision collision);
    public abstract void ChangeState(WeaponIState newState);
}
