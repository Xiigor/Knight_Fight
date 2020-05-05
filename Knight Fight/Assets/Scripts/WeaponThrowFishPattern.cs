using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrowFishPattern : WeaponBaseClass
{
    public float durabilityDecrement;
    public GameObject weaponAmmo;
    public int numberofAmmoToSpawn;
    public float spawnOfsettDist;
    public enum LaunchDir { forward, up, left, right };
    public LaunchDir launchDir;
    private float currentDurability;
    private float spawnOffset = 0;
    private int increaseSpawnOffsett = 1;
  
    private void Awake()
    {
        unequippedState = new WeaponUnequippedState(this);
        equippedState = new WeaponEquippedState(this);
        thrownState = new WeaponThrownState(this);
        thisWepType = Weapontype.spellbook;
        
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
    }

    public override void Attack()
    {
        //launch projectile and instanciate projectile 
        // Projectile i eget script med en OnCollisonEnter kollar om träffat en spelare och isfall gå in i enemy.gameObject.GetComponent<PlayerStatePattern>().OnHit(damage);
        ChangeDurability(durabilityDecrement);
        //Instantiate(weaponAmmo);
        for (int i = 0; i < numberofAmmoToSpawn; i++)
        {
            audioPlayer.Attacking();
            Vector3 spawnOffsetVec = new Vector3(0,0,0);
            GameObject temp = Instantiate(weaponAmmo, parentPlayer.GetComponent<PlayerStatePattern>().projectileSpawnPos.transform.position, Quaternion.identity);
            //spawnOffsetVec = temp.transform.localPosition - parentPlayer.transform.position;
            //Debug.Log(spawnOffsetVec);
            //spawnOffsetVec.x = spawnOffsetVec.x - spawnOffset * spawnOffsetVec.z / Mathf.Sqrt(spawnOffsetVec.x * spawnOffsetVec.x + spawnOffsetVec.z * spawnOffsetVec.z);
            //spawnOffsetVec.z = spawnOffsetVec.z - spawnOffset * spawnOffsetVec.x / Mathf.Sqrt(spawnOffsetVec.x * spawnOffsetVec.x + spawnOffsetVec.z * spawnOffsetVec.z);
            //temp.transform.localPosition = spawnOffsetVec + parentPlayer.transform.position;
            //spawnOffsetVec.z = spawnOffset * temp.transform.localPosition.x / (Mathf.Sqrt(temp.transform.localPosition.x* temp.transform.localPosition.x + temp.transform.localPosition.z * temp.transform.localPosition.z));
            //spawnOffsetVec.x = spawnOffset * temp.transform.localPosition.z / (Mathf.Sqrt(temp.transform.localPosition.x * temp.transform.localPosition.x + temp.transform.localPosition.z * temp.transform.localPosition.z));
            //temp.transform.localPosition = temp.transform.localPosition + spawnOffsetVec;
            
            temp.GetComponent<ProjectileFish>().parentObject = parentPlayer.GetComponent<PlayerStatePattern>().projectileSpawnPos;
            temp.GetComponent<ProjectileFish>().spellBook = this.gameObject;
            spawnOffset = spawnOffset * (-1);
            Debug.Log(parentPlayer.GetComponent<PlayerStatePattern>().projectileSpawnPos.transform.forward);
            increaseSpawnOffsett++;
            if (increaseSpawnOffsett == 2)
            {
               
                spawnOffset += spawnOfsettDist;
                increaseSpawnOffsett = 0;
            }
            
            //transform.DetachChildren();
        }
        spawnOffset = 0;
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
}
