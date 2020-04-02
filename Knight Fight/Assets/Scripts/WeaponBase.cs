// Author Joakim Karlsteen 
// 01-04-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
  
   
    public int damage = 10;
    public float attackspeed = 1.0f;
    //public int spawnRarity;
    public float attackrange = 0.5f;
    

    // Meleeattack kollar om en sfär överlappar med en annan spelare om så är fallet så tar spelaren dmg
    public virtual void MeleeAttack(Transform attackPoint, float attackRange, GameObject attackingPlayer)
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
    public virtual void RangedAttack()
    {
        //kommer overrideas i själva vapen scriptet
    }
    public void RemoveHealth(int damage, Collider enemy)
    {
        Debug.Log(enemy);
    }


}

