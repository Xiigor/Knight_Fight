using FMOD;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBananaTreePattern : WeaponBaseClass
{
    public float durabilityDecrement;
    public GameObject weaponAmmo;
    public GameObject projectileSpawnPoint;
    public float timeDelayProjectile;
    public float upSpeedProjectile;
    [HideInInspector]public Vector3 swordVel;

    private float currentDurability;
    private bool newAttack = false;
    private float timeDelayTimer = 0;

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
        audioPlayer = GetComponent<AudioWeapon>();
    }

    private void Update()
    {
        currentState.UpdateState();
        timeDelayTimer += Time.deltaTime;
        if (gameObject.GetComponent<Collider>().enabled == true && timeDelayTimer >= timeDelayProjectile && currentState == equippedState)
        { 
            GameObject temp = Instantiate(weaponAmmo, projectileSpawnPoint.transform.position, Quaternion.identity);
            temp.GetComponent<ProjectileBanana>().parentObject = this.gameObject;
            temp.GetComponent<ProjectileBanana>().spellBook = this.gameObject;
            timeDelayTimer = 0f;
            Vector3 swordDir = gameObject.transform.position - parentPlayer.transform.position;
            Vector3 swardDir = swordDir;
            swardDir.y = 0;
            swordVel = new Vector3(-swardDir.z,upSpeedProjectile,swardDir.x); 
            
        }
    }

    public override void Attack()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        newAttack = true;
        parentPlayer.GetComponent<PlayerStatePattern>().animator.GetCurrentAnimatorStateInfo(0).IsName("2HSword Attack");
        //Debug.Log("attack");
        timeDelayTimer = -0.5f;
        // attackanimationen körs och kollar i update när den är klar och stänger av collidern igen
    }

    public override void ChangeDurability(float durabilityDecrement)
    {
        currentDurability -= durabilityDecrement;
        if (currentDurability <= 0)
        {
            parentPlayer.GetComponent<PlayerStatePattern>().weaponDestroyed = true;
            Destroy(this.gameObject);
        }
    }
    public override void ChangeState(WeaponIState newState)
    {
        currentState = newState;
        currentState.OnStateEnter();
    }
    public override void OnCollisionEnter(Collision collision)
    {
        currentState.HandleCollision(collision);
        if (collision.gameObject.tag == playerTag && newAttack == true)
        {
            ChangeDurability(durabilityDecrement);
            newAttack = false;
        }

    }
}
