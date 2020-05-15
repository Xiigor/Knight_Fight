using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBananaTreePattern : WeaponBaseClass
{
    public float durabilityDecrement;
    public GameObject weaponAmmo;
    public float timeDelayProjectile;

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
        if (newAttack == true)
        {
            ChangeDurability(durabilityDecrement);
            newAttack = false;
        }
        timeDelayTimer += Time.deltaTime;
        if (gameObject.GetComponent<Collider>().enabled == true && timeDelayTimer >= timeDelayProjectile && parentPlayer != null)
        { 
            GameObject temp = Instantiate(weaponAmmo, this.gameObject.transform.position, Quaternion.identity);
            //temp.GetComponent<ProjectileFish>().parentObject = parentPlayer;
            temp.GetComponent<ProjectileFish>().parentObject = this.gameObject;
            temp.GetComponent<ProjectileFish>().spellBook = this.gameObject;
            timeDelayTimer = 0.1f;
        }
    }

    public override void Attack()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        newAttack = true;
        parentPlayer.GetComponent<PlayerStatePattern>().animator.GetCurrentAnimatorStateInfo(0).IsName("2HSword Attack");
        Debug.Log("attack");
        timeDelayTimer = 0;
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

    }
}
