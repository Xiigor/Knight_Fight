using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string playerTag = "Player";
    public WeaponSpawnManager weaponSpawner;

    private void Start()
    {
        weaponSpawner = GameObject.FindObjectOfType<WeaponSpawnManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == playerTag)
        {
            collision.gameObject.GetComponent<PlayerStatePattern>().OnHit(100);
        }
        else if (weaponSpawner.activeWeaponsList.Contains(collision.gameObject))
        {
            weaponSpawner.activeWeaponsList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
        
    }
}
