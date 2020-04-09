using System.Collections;
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
        currentState.UpdateState();
    }

    public override void Attack()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(this.transform.position, attackZone); 
        foreach (Collider enemy in hitPlayer)
        {
            // delar endast ut dmg på spelaren och inte andra objekt som råkar bli träffad och inte på sig själv
            if (enemy.gameObject.layer == 8)
            {
                if (enemy.gameObject.name == parentPlayer.gameObject.name) 
                {
                    //Gör inget 
                    // Debug.Log(attackingPlayer.name + " Hit my self " + enemy.gameObject.name); 
                }
                else
                {
                   ChangeDurability(durabilityDecrement);
                   enemy.gameObject.GetComponent<PlayerStatePattern>().OnHit(damage);
                }
            }
        }
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

    //visuellt visa träffzonen
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackZone);

    }
}
