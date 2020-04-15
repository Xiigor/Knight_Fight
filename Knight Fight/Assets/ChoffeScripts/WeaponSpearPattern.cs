using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpearPattern : WeaponBaseClass
{
    public float attackZone = 1.0f;
    public float durabilityDecrement;
    public Vector3 offestAttackZonePos;
    // Start is called before the first frame update
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
        
        //Vector3 attackZoneCenter = this.gameObject.transform.TransformPoint(offestAttackZonePos);
        //Collider[] hitPlayer = Physics.OverlapSphere(attackZoneCenter, attackZone);
        //foreach (Collider enemy in hitPlayer)
        //{
            
            // delar endast ut dmg på spelaren och inte andra objekt som råkar bli träffad och inte på sig själv
            if (enemy.gameObject.layer == 8)
            {
                if (enemy.gameObject.name == parentPlayer.gameObject.name)
                {
                  //Gör inget 
                  //Debug.Log(this.gameObject.GetComponentInParent<GameObject>().name + " Hit my self " + enemy.gameObject.name); 
                 
                }
                else
                {
                  ChangeDurability(durabilityDecrement);
                  enemy.gameObject.GetComponent<PlayerStatePattern>().OnHit(damage);
                  Debug.Log("Attack");

                }
            }
        //}
       
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
   

    ////visuellt visa träffzonen
    //void OnDrawGizmos()
    //{
    //    Vector3 Pos = this.gameObject.transform.TransformPoint(offestAttackZonePos);
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(Pos, attackZone);

    //}
}
