﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwordPattern : WeaponBaseClass
{
    
    public float attackZone;
    public float durabilityDecrement;
    // FIXA BUGGAR FÖRST INNAN DU FORTSÄTTER, SPELAREN ROTERAR INNAN VAPNET KASTAS IVÄG OCH DET ÄR FUCKING WEIRD. VAPNET KASTAS INTE ALLTID RAKT FRAM HELLER
    private float currentDurability;

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

    public override void Attack(Collision enemy)
    {
            // delar endast ut dmg på spelaren och inte andra objekt som råkar bli träffad
            if (enemy.gameObject.layer == 8)
            {
               ChangeDurability(durabilityDecrement);
               enemy.gameObject.GetComponent<PlayerStatePattern>().OnHit(damage);  
            }
    }

    public override void ThrownAttack(Collision col)
    {
        col.gameObject.GetComponent<PlayerStatePattern>().OnHit(thrownDamage);
    }

    public override void ChangeDurability(float durabilityDecrement)
    {
        currentDurability -= durabilityDecrement;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        currentState.HandleCollision(collision);
        Attack(collision);
    }
    


    //visuellt visa träffzonen
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(this.transform.position, attackZone);

    //}
    }
