// Author Joakim Karlsteen 
// 01-04-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : WeaponBase
{
   public int PlayerLayer = 8;
   public Transform attackPoint;
   //private GameObject attackingPlayer;
   //public Animation Sword;
   
   void Start()
    {
        //attackPoint = this.transform;
    }     
   void Update()
    {
        //SwingSword();
    }


   public void SwingSword(GameObject attackingPlayer)
    {   
        
        MeleeAttack(attackPoint, attackrange, attackingPlayer);
    }

    // Meleeattack kollar om en sfär överlappar med en annan spelare om så är fallet så tar spelaren dmg
    public override void MeleeAttack(Transform attackPoint, float attackRange, GameObject attackingPlayer)
    {

        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackrange);
        foreach (Collider enemy in hitPlayer)
        {
            // delar endast ut dmg på spelaren och inte andra objekt som råkar bli träffad och inte på sig själv
            if (enemy.gameObject.layer == 8)
            {
                if (enemy.gameObject.name == attackingPlayer.name)
                {
                    //Gör inget 
                    // Debug.Log(attackingPlayer.name + " Hit my self " + enemy.gameObject.name); 
                }
                else
                {
                    Durability(this.gameObject);
                    //Scriptet med removehelth i RemoveHealth(damage); Skickar med hur mycket dmg och på vem
                    
                    RemoveHealth(damage, enemy);

                }

            }


        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackrange);

    }
}
