using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwordPattern : WeaponBaseClass
{
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

    public override void Attack()
    {
        //do this weapons specific attack
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
    }
}
