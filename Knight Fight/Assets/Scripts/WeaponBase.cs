// Author Joakim Karlsteen 
// 01-04-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
  

    public int damage;
    public float attackspeed;
    public int spawnRarity;
    public float attackrange = 0.5f;
    

    // Meleeattack kollar om en sfär överlappar med en annan spelare om så är fallet så tar spelaren dmg
    public virtual void MeleeAttack(Transform attackPoint, float attackRange)
    {

        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackrange);
        foreach (Collider enemy in hitPlayer)
        {
            //Scriptet med removehelth i RemoveHealth(damage);
            RemoveHealth(damage);
        }
    }
    public virtual void RangedAttack()
    {
        //kommer overrideas i själva vapen scriptet
    }
    public void RemoveHealth(int damage)
    {
        Debug.Log("hit");

    }


}

