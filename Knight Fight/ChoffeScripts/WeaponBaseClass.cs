using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class WeaponBaseClass : MonoBehaviour
{
    public GameObject parentPlayer = null;
    public GameObject damageZoneObject = null;

    public WeaponIState currentState;
    [HideInInspector] public WeaponUnequippedState unequippedState;
    [HideInInspector] public WeaponEquippedState equippedState;
    [HideInInspector] public WeaponThrownState thrownState;
    
    public float durability;
    public float damage;
    public float thrownDamage;
    public float thrownForce;
    public float throwAngle;

    public string environmentTag = "Environment";
    public string playerTag = "Player";
    public string projectileTag = "Projectile";
    public string weaponTag = "Weapon";
<<<<<<< HEAD
    public Vector3 damageZonePosition;
=======

    public int UnequippedLayer = 13;
    public int EquippedLayer = 14;

>>>>>>> Progg-Choffe
    public Vector3 heldPosition;
    public Vector3 heldRotation;
    public Rigidbody rb;
    public Collider col;
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
        //sätter spelaren till förälder
        transform.SetParent(collision.transform.GetChild(0));

        parentPlayer = collision.gameObject;

        //parentPlayer = collision.gameObject.GetComponent<PlayerStatePattern>(); //osäker på ifall detta behövs... 
        // ...bra referens för att Unequipped vapen ska kunna kolla ifall spelaren redan har ett vapen
        // spelaren kommer kunna behöva anropa vapnets funktioner baserat på input men kanske inte tvärt om
    }
    public void RemoveParentPlayer()
    {
        transform.parent = null;
    }
    public abstract void OnCollisionEnter(Collision collision);
    public abstract void ChangeState(WeaponIState newState);
}
