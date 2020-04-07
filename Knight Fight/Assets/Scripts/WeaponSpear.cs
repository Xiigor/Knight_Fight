// Author Joakim Karlsteen 
// 02-04-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpear : WeaponBase
{
    public Transform attackPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpearAttack(GameObject attackingPlayer)
    {

        MeleeAttack(attackPoint, attackrange, attackingPlayer);
    }

    // Meleeattack kollar om en sfär överlappar med en annan spelare om så är fallet så tar spelaren dmg
    public override void MeleeAttack(Transform attackPoint, float attackRange, GameObject attackingPlayer)
    {

        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackrange);
        foreach (Collider enemy in hitPlayer)
        {
            // delar endast ut dmg på spelaren och inte andra objekt som råkar bli träffad 
            if (enemy.gameObject.layer == 8)
            {
                RemoveHealth(damage, enemy);

            }


        }
        
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackrange);

    }
}
