using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ProjectileBase : MonoBehaviour
{
    public ProjectileIState currentState;
    public float damage;
    //public PlayerStatePattern parentObject = null;
    public GameObject parentObject = null;
    [HideInInspector] public GameObject Player;
    [HideInInspector] public Transform projectileTransform;
    [HideInInspector] public int i = 1;
    [HideInInspector] public ProjectileFlyingState flyingState;
    [HideInInspector] public ProjectileGroundedState groundedState;
    public Rigidbody rb;

    public float ProjectileSpeed = 15f;
    public string playerTag = "Player";

    public abstract void LaunchPos(GameObject parent);
    public abstract void StateChanger(ProjectileIState newState);
    
}
