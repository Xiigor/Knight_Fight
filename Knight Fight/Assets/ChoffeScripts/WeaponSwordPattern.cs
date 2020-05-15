﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwordPattern : WeaponBaseClass
{
    public float durabilityDecrement;
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
        audioPlayer = GetComponent<AudioWeapon>();  
    }

    private void Update()
    {
        currentState.UpdateState();
        if(internalAttackTimer >= animationDuration && attackActive == true)
        {
            col.enabled = false;
            attackActive = false;
        }
    }

    public override void Attack()
    {
        attackActive = true;
        internalAttackTimer = 0f;
        col.enabled = true;
        // attackanimationen körs och kollar i update när den är klar och stänger av collidern igen
    }

    public override void ChangeDurability(float durabilityDecrement)
    {
        currentDurability -= durabilityDecrement;
        if (currentDurability <= 0)
        {
            parentPlayer.GetComponent<PlayerStatePattern>().weaponDestroyed = true;
            Destroy(this.gameObject);
        }
    }
    public override void ChangeState(WeaponIState newState)
    {
        currentState = newState;
        currentState.OnStateEnter();
    }
    public override void OnCollisionEnter(Collision collision)
    {
        currentState.HandleCollision(collision);
        if(collision.gameObject.tag == playerTag)
        {
            ChangeDurability(durabilityDecrement);
        }
        
    }
}
