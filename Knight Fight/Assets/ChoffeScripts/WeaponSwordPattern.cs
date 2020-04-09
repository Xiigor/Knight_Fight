using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwordPattern : WeaponBaseClass
{ 
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
        currentState.UpdateState();
    }

    public override void Attack()
    {
        //do this weapons specific attack
    }

    public override void ChangeDurability(float durabilityDecrement)
    {
        currentDurability -= durabilityDecrement;
    }
    public override void ChangeState(WeaponIState newState)
    {
        currentState = newState;
        currentState.OnStateEnter();
    }
    public override void OnCollisionEnter(Collision collision)
    {
        currentState.HandleCollision(collision);
    }
}
