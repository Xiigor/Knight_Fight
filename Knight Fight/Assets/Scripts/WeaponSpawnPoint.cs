using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnPoint : MonoBehaviour
{
    public int maxForwardSpeed = 75;
    public int minForwardSpeed = 75;
    public int maxUpSpeed = 50;
    public int minUpSpeed = 50;
    [HideInInspector] public int randomForwardSpeed, randomUpSpeed;

    public void RandomThrowSpeed()
    {
        randomForwardSpeed = Random.Range(minForwardSpeed, maxForwardSpeed);
        randomUpSpeed = Random.Range(minUpSpeed, maxUpSpeed);
    }
}
