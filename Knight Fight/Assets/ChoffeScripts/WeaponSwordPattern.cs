using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwordPattern : WeaponBaseClass
{
    public string attackAnimName;
    public float durabilityDecrement;
    private float currentDurability;
    
    private void Awake()
    {
        unequippedState = new WeaponUnequippedState(this);
        equippedState = new WeaponEquippedState(this);
        thrownState = new WeaponThrownState(this);
        thisWepType = Weapontype.oneHSword;
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
    }

    public override void Attack()
    {
        //gameObject.GetComponent<Collider>().enabled = true;
        // attackanimationen körs och kollar i update när den är klar och stänger av collidern igen
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
