using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrowFishPattern : WeaponBaseClass
{
    public float durabilityDecrement;
    public GameObject weaponAmmo;
    private float currentDurability;
  
    private void Awake()
    {
        unequippedState = new WeaponUnequippedState(this);
        equippedState = new WeaponEquippedState(this);
        thrownState = new WeaponThrownState(this);
        thisWepType = Weapontype.spellbook;
    }

    private void Start()
    {
        currentState = stateChangeObserver = unequippedState;
        currentDurability = durability;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        audioPlayer = GetComponent<AudioWeapon>();

    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public override void Attack()
    {
        //launch projectile and instanciate projectile 
        // Projectile i eget script med en OnCollisonEnter kollar om träffat en spelare och isfall gå in i enemy.gameObject.GetComponent<PlayerStatePattern>().OnHit(damage);
        ChangeDurability(durabilityDecrement);
        //Instantiate(weaponAmmo);
        audioPlayer.Attacking();
        Instantiate(weaponAmmo, this.transform);
        transform.DetachChildren();
    }

    public override void ChangeDurability(float durabilityDecrement)
    {
        currentDurability -= durabilityDecrement;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        currentState.HandleCollision(collision);
    }

    public override void ChangeState(WeaponIState newState)
    {
        currentState = newState;
        currentState.OnStateEnter();
    }

    public override void SetWeaponType()
    {
        parentPlayer.GetComponent<Animator>().SetBool("Spellbook", true);
    }

    public override void RemoveWeaponType()
    {
        parentPlayer.GetComponent<Animator>().SetBool("Spellbook", false);
    }
}
