using System.Collections;
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
        if(internalAttackTimer >= animationDuration)
        {
            col.enabled = false;
            attackActive = false;
        }
    }

    public override void Attack()
    {
<<<<<<< HEAD
        gameObject.GetComponent<Collider>().enabled = true;
        Debug.Log("attack");
=======
        attackActive = true;
        internalAttackTimer = 0f;
        col.enabled = true;
>>>>>>> eb45a01c9538b18ddcd13b99180cbaa8bea8c88a
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
