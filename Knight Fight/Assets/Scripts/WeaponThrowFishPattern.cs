using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrowFishPattern : WeaponBaseClass
{
    public float durabilityDecrement;
    public GameObject weaponAmmo;
    private float currentDurability;
    private Collision apa; // Funkar inte utan att skicka med denna
    private void Awake()
    {
        unequippedState = new WeaponUnequippedState(this);
        equippedState = new WeaponEquippedState(this);
        thrownState = new WeaponThrownState(this);
    }

    private void Start()
    {
        currentState = unequippedState;
        currentDurability = durability;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        
    }

    private void Update()
    {
        StateChangeObserver();
       
    }

    public override void Attack()
    {
        //launch projectile and instanciate projectile 
        // Projectile i eget script med en OnCollisonEnter kollar om träffat en spelare och isfall gå in i enemy.gameObject.GetComponent<PlayerStatePattern>().OnHit(damage);
        ChangeDurability(durabilityDecrement);
        Instantiate(weaponAmmo);
    }

    public override void ChangeDurability(float durabilityDecrement)
    {
        currentDurability -= durabilityDecrement;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        currentState.HandleCollision(collision);
    }

    public override void ThrownAttack(Collision col)
    {
        col.gameObject.GetComponent<PlayerStatePattern>().OnHit(thrownDamage);
    }
   



}
