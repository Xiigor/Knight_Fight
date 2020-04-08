// Author Joakim Karlsteen 
// 03-04-2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Scriptet är bara till för testing när ingen karaktär finns
public class Attack : MonoBehaviour
{
    private WeaponSword Sword;
    //private WeaponSpear spear;

    // Start is called before the first frame update
    void Start()
    {
         Sword = GetComponentInChildren<WeaponSword>();
         //spear = GetComponentInChildren<WeaponSpear>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!(Sword == null))
        {
            Sword.SwingSword(gameObject);
        }
       
        //spear.SpearAttack(gameObject);
    }
}
