using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageZone : MonoBehaviour
{
    public string playerTag = "Player";
    public float damage;
    public float aliveDuration;
    public float internalTimer;
    public GameObject parentPlayer;

    private void Start()
    {
        internalTimer = aliveDuration;
    }

    public void Update()
    {
        internalTimer += Time.deltaTime;
        if (internalTimer >= aliveDuration)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        internalTimer = 0f;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == playerTag)
        {
            other.gameObject.GetComponent<PlayerStatePattern>().OnHit(damage);
        }
    }
}
