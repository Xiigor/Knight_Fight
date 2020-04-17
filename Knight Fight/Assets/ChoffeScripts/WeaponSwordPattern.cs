using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwordPattern : WeaponBaseClass
{
    public string attackAnimName;
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

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(attackAnimName)) // tror den checkar om animatinen är klar
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    public override void Attack()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        anim = parentPlayer.GetComponent<Animator>();    //Hämta parent animator Så kan kolla om färdig
        // attackanimationen körs och kollar i update när den är klar och stänger av collidern igen
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
    


    //visuellt visa träffzonen
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(this.transform.position, attackZone);

    //}
    }
