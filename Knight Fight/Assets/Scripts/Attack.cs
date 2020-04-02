using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private WeaponSword Sword;
    private WeaponSpear spear;

    // Start is called before the first frame update
    void Start()
    {
         Sword = GetComponentInChildren<WeaponSword>();
         spear = GetComponentInChildren<WeaponSpear>();

    }

    // Update is called once per frame
    void Update()
    {
        //Sword.SwingSword(gameObject);
        spear.SpearAttack(gameObject);
    }
}
