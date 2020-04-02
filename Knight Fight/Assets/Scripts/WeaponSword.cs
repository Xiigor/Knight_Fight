// Author Joakim Karlsteen 
// 01-04-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : WeaponBase
{

   public Transform attackPoint;
   //public Animation Sword;
    
   void Update()
    {
        //SwingSword();
    }


   void SwingSword()
    {   
        
        MeleeAttack(attackPoint, attackrange);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackrange);
        
    }

   


}
