// Author Joakim Karlsteen 
// 01-04-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypes
{
    Melee, Ranged, Magic
}
public enum Weapons
{
    Sword, Spear
};

public class WeaponBase : MonoBehaviour
{
    public WeaponTypes weaponType;
    public Weapons weapon;
    
    public int damage = 10;
    public float attackspeed = 1.0f;
    //public int spawnRarity;
    public float attackrange = 0.5f;
    public int durability = 10; // Dubblerar som antal slag för melee vapen och ammo för ranged vapen
    

    // Meleeattack kollar om en sfär överlappar med en annan spelare om så är fallet så tar spelaren dmg
    public virtual void MeleeAttack(Transform attackPoint, float attackRange, GameObject attackingPlayer)
    {

        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackrange); 
        foreach (Collider enemy in hitPlayer)
        {
            // delar endast ut dmg på spelaren och inte andra objekt som råkar bli träffad 
            if (enemy.gameObject.layer == 8)
            {
                    //Durability(this.gameObject); 
                    RemoveHealth(damage, enemy);
            }   
        }
    }

    public virtual void RangedAttack()
    {
        //kommer overrideas i själva vapen scriptet
    }

    // Kallas varje gång du träffar någon eller skjuter med ett vapen
    public virtual void Durability(GameObject weapon)
    {
        durability -= 1;
        if (durability <= 0)
        {
            Destroy(weapon);
        }
    }

    public void RemoveHealth(int damage, Collider enemy)
    {
        Debug.Log(enemy);
    }


}

