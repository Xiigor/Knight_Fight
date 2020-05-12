﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatePattern : MonoBehaviour
{
    public PlayerIState currentState;
    [HideInInspector]public GameManager gameManager;
    public PlayerRagdollHandler ragdollHandler;

    [HideInInspector] public PlayerBasicState basicState;
    [HideInInspector] public PlayerIdleState idleState;
    [HideInInspector] public PlayerDashState dashState;
    [HideInInspector] public PlayerThrowState throwState;
    [HideInInspector] public PlayerAttackState attackState;
    [HideInInspector] public PlayerDeadState deadState;

    public GameObject rightHandGameobject = null;
    public GameObject leftHandGameobject = null;
    public GameObject projectileSpawnPos = null;


    public  float globalCD = 0.5f;
    public float dashCD = 0.2f;
    public float attackCD = 0.5f;
    [HideInInspector]  public  float internalGCDTimer;
    [HideInInspector] public float internalDashTimer;
    [HideInInspector] public float internalAttackTimer;

    public float movementSpeedMultiplier = 35.0f;

    public float dashDuration = 0.1f;
    public float dashSpeed = 500.0f;
    [HideInInspector] public float attackAnimDuration;
    public float throwAnimDuration = 0.5f;
    private float movementInputForDashDirThreshhold = 0.15f; 
    public float internalDashRayDist = 1.3f;
    public bool canDash = true;

    public GameObject weapon;

    //tags
    public string weaponTag = "Weapon";
    public string weaponProjectileTag = "WeaponProjectile";
    public string projectileTag = "Projectile";
    public string environmentTag = "Environment";
    public string playerTag = "Player";
    public string deadPlayerTag = "DeadPlayer";

    //values
    [HideInInspector] public Vector2 moveDir;
    Vector2 moveLastDir;
    Vector3 move;
    Vector3 lastMove;
    public float maxHealth = 100f;
    public float health;


    [HideInInspector] public Collider col;
    [HideInInspector] private Rigidbody rb;
    [HideInInspector] public AudioPlayer audioPlayer;
    public Animator animator;



    public int UnequippedLayer = 13;
    public int EquippedLayer = 14;
    [SerializeField] private int playerIndex;
    public GameObject spawnPosition;


    private void Awake()
    {
        basicState = new PlayerBasicState(this);
        idleState = new PlayerIdleState(this);

        dashState = new PlayerDashState(this);
        throwState = new PlayerThrowState(this);
        deadState = new PlayerDeadState(this);
        attackState = new PlayerAttackState(this);
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioPlayer = GetComponent<AudioPlayer>();
        animator = GetComponent<Animator>();

    }

    public void OnEnable()
    {
        transform.position = spawnPosition.transform.position;
        health = maxHealth;
        tag = playerTag;
        currentState = idleState;
        currentState.OnStateEnter();
        internalGCDTimer = globalCD;
        internalDashTimer = dashCD;
        weapon = null;
        Physics.IgnoreLayerCollision(gameObject.layer, UnequippedLayer, false);
    }

    public void OnDisable()
    {
        transform.position = spawnPosition.transform.position;
    }

    private void FixedUpdate()
    {
        Ray environmentRay = new Ray(transform.position, lastMove);
        RaycastHit environmentRayHit;

        if (Physics.Raycast(environmentRay, out environmentRayHit, internalDashRayDist))
        {
            if (environmentRayHit.transform.tag == environmentTag)
            {
                canDash = false;
            }
        }
        else
        {
            canDash = true;
        }
    }

    private void Update()
    {
        currentState.UpdateState();
        if (internalGCDTimer < globalCD)
        {
            internalGCDTimer += Time.deltaTime;
        }
        if (internalDashTimer < dashCD)
        {
            internalDashTimer += Time.deltaTime;
        }
        if (internalAttackTimer < attackCD)
        {
            internalAttackTimer += Time.deltaTime;
        }
    }
    public int GetPlayerIndex()
    {
        return playerIndex;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(currentState != deadState)
        {
            if (collision.gameObject.tag == weaponProjectileTag)
            {
                OnHit(collision.gameObject.GetComponent<WeaponBaseClass>().thrownDamage);
            }
            if (collision.gameObject.tag == projectileTag)
            {
                OnHit(collision.gameObject.GetComponent<ProjectileBase>().damage);
            }
            if(collision.gameObject.tag == weaponTag)
            {
                if (collision.gameObject.layer == UnequippedLayer)
                {
                    PickupItem(collision.gameObject);
                }
                else if (collision.gameObject.layer == EquippedLayer)
                {

                    OnHit(collision.gameObject.GetComponent<WeaponBaseClass>().damage);
                } 
            }
        }
        if (currentState == dashState)
        {
            currentState.ChangeState(idleState);
        }
    }

    public void Attack()
    {
        if(weapon != null)
        {
            weapon.GetComponent<WeaponBaseClass>().Attack();
        }
        else
        {
            //audioPlayer.PlayerUnarmedAttack(); --- detta får nog vänta lite
            //do basic punch attack.
        }
    }

    public bool ValidStateChange(PlayerIState newState)
    {
        if (internalGCDTimer >= globalCD)
        {
            if (newState == dashState)
            {
                if (internalDashTimer >= dashCD)
                {
                    return true;
                }
                else
                {
                    Debug.Log("Dash on cooldown");
                    return false;
                }
            }
            if(newState == throwState)
            {
                if(weapon != null)
                {
                    audioPlayer.PlayerThrowing();
                    Debug.Log("throw wep");
                    return true;
                }
                else
                {
                    Debug.Log("nothing to throw");
                    return false;
                }
            }
            if (newState == attackState)
            {
                if (internalAttackTimer >= attackCD)
                {
                    if (weapon != null)
                    {
                        Debug.Log("attack with wep");
                        return true;
                    }
                    else
                    {
                        Debug.Log("nothing to attack with");
                        return false;
                    }
                }
                else
                {
                    Debug.Log("Attack on cooldown");
                    return false;
                }
            }
            else
            {
                Debug.Log("invalid state");
                return false;
            }
        }
        else
        {
            Debug.Log("Global cooldown!");
            return false;
        }
    }

    public void StateChanger(PlayerIState newState)
    {
        if(newState == deadState)
        {
            currentState = newState;
            currentState.OnStateEnter();
        }
        else if(newState == idleState || newState == basicState)
        {
            currentState = newState;
            currentState.OnStateEnter();
        }
        else if(currentState == idleState || currentState == basicState)
        {
            if (ValidStateChange(newState))
            {
                currentState = newState;
                currentState.OnStateEnter();
            }
        }
    }

    public void RunOrIdleDecider()
    {
        if(moveDir == Vector2.zero)
        {
            currentState.ChangeState(idleState);
        }
        else
        {
            currentState.ChangeState(basicState);
        }
    }

    public void WeaponTypeIdentifier()
    {
        switch (weapon.GetComponent<WeaponBaseClass>().thisWepType)
        {
            case WeaponBaseClass.Weapontype.oneHSword:
                animator.SetBool("1hSword", true);
                animator.SetBool("2hSword", false);
                animator.SetBool("Spellbook", false);
                break;
            case WeaponBaseClass.Weapontype.twoHSword:
                animator.SetBool("1hSword", false);
                animator.SetBool("2hSword", true);
                animator.SetBool("Spellbook", false);
                break;
            case WeaponBaseClass.Weapontype.spellbook:
                animator.SetBool("1hSword", false);
                animator.SetBool("2hSword", false);
                animator.SetBool("Spellbook", true);
                break;
        }
    }

    public void ChangeDirection()
    {
        //move = Vector3.Normalize(new Vector3(moveDir.x, 0.0f, moveDir.y) * Time.deltaTime * movementSpeedMultiplier);
        if (Hypotenuse(moveDir.x, moveDir.y) >= movementInputForDashDirThreshhold)
        {
            move = Vector3.Normalize(new Vector3(moveDir.x, 0.0f, moveDir.y) * Time.deltaTime * movementSpeedMultiplier);
            moveLastDir = moveDir;
        }
        else
        {
            moveDir = Vector2.zero;
        }

        lastMove = Vector3.Normalize(new Vector3(moveLastDir.x, 0.0f, moveLastDir.y) * Time.deltaTime * movementSpeedMultiplier);
        transform.forward = lastMove;
    }

    public void Movement()
    {
        rb.velocity = move * movementSpeedMultiplier;
    }

    public void Dash()
    {
        transform.Translate(lastMove * dashSpeed * Time.deltaTime, Space.World);
    }

    public void ThrowItem()
    {
        weapon.GetComponent<WeaponBaseClass>().ThrowWep();
        weapon = null;
        animator.SetBool("1hSword", false);
        animator.SetBool("2hSword", false);
        animator.SetBool("Spellbook", false);
        Physics.IgnoreLayerCollision(gameObject.layer, UnequippedLayer, false);
    }

    public void PickupItem(GameObject weaponObject)
    {
        weapon = weaponObject;
        Physics.IgnoreCollision(col, weapon.GetComponent<Collider>(), true);
        Physics.IgnoreLayerCollision(gameObject.layer, UnequippedLayer, true);
        attackAnimDuration = weapon.GetComponent<WeaponBaseClass>().animationDuration;
        weapon.gameObject.layer = EquippedLayer; //läggs här för att inte ske före on collision
        WeaponTypeIdentifier();
    }

    public void OnHit(float damage)
    {
        audioPlayer.PlayerHurting();
        currentState.TakeDamage(damage);
    }

    public void EnableRagdoll()
    {
        ragdollHandler.SetRagdollActive();
        animator.enabled = false;
    }

    public void DisableRagdoll()
    {
        ragdollHandler.SetRagdollInactive();
        animator.enabled = true;

    }

    public void Die()
    {
        StateChanger(deadState);
    }

    private float Hypotenuse(float sideA, float sideB)
    {
        return Mathf.Sqrt(sideA * sideA + sideB * sideB);
    }
}
