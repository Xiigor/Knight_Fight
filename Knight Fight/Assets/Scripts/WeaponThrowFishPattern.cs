﻿using System.Collections;
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
        gameManager = GameObject.Find("GameManager");

    }

    private void Update()
    {
        StateChangeObserver();
        if (currentDurability <= 0)
        {
            gameManager.GetComponent<WeaponSpawnManager>().activeWeaponsList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
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

    public override void ChangeState(WeaponIState newState)
    {
        currentState = newState;
        currentState.OnStateEnter();
    }
}
