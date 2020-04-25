using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatePattern : MonoBehaviour
{
    public PlayerIState currentState;
    private PlayerIState stateChangeObserver;

    [HideInInspector] public PlayerBasicState basicState;
    [HideInInspector] public PlayerIdleState idleState;
    [HideInInspector] public PlayerDashState dashState;
    [HideInInspector] public PlayerThrowState throwState;
    [HideInInspector] public PlayerAttackState attackState;
    [HideInInspector] public PlayerDeadState deadState;
    

    public  float globalCD = 0.5f;
    public float dashCD = 0.2f;
    public float attackCD = 0.5f;
    [HideInInspector]  public  float internalGCDTimer;
    [HideInInspector] public float internalDashTimer;
    [HideInInspector] public float internalAttackTimer;

    //weapontype for the currently equipped weapon
    public bool currentWeaponIs1HSword = false;
    public bool currentWeaponIs2HSword = false;
    public bool currentWeaponIsSpellbook = false;

    public float movementSpeedMultiplier = 35.0f;

    public float dashDuration = 0.1f;
    public float dashSpeed = 500.0f;
    public float attackAnimDuration;
    private float movementInputForDashDirThreshhold = 0.25f; //Fixa så att movement är 0 eller 1
    public float internalDashRayDist = 1.3f;
    public bool canDash = true;

    public GameObject weapon;

    //tags
    public string weaponTag = "Weapon";
    public string projectileTag = "Projectile";
    public string environmentTag = "Environment";

    //values
    [HideInInspector] public Vector2 moveDir;
    Vector2 moveLastDir;
    Vector3 move;
    public Vector3 lastMove;
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
        //currentState = stateChangeObserver = idleState;

        dashState = new PlayerDashState(this);
        throwState = new PlayerThrowState(this);
        deadState = new PlayerDeadState(this);
        attackState = new PlayerAttackState(this);
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioPlayer>();
        animator = GetComponent<Animator>();

    }

    public void OnEnable()
    {
        transform.position = spawnPosition.transform.position;
        health = maxHealth;
        currentState = stateChangeObserver = idleState;
        internalGCDTimer = globalCD;
        internalDashTimer = dashCD;
        weapon = null;
        Physics.IgnoreLayerCollision(gameObject.layer, UnequippedLayer, false);
    }

    private void FixedUpdate()
    {
        //StateUpdateObserver();
        currentState.UpdateState();
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
        if (collision.gameObject.tag == projectileTag)
        {
            OnHit(collision.gameObject.GetComponent<WeaponBaseClass>().thrownDamage);
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
                    audioPlayer.PlayerDashing(); // --- trigger dash sound, try if it works better being placed here
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
                        Attack(); // ---- anropet till attackfunktionen, spelaren går in i attackstate och går in i idle när animationen är färdig.
                        Debug.Log("attack with wep");
                        weapon.GetComponent<AudioWeapon>().Attacking();
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
        currentState = newState;
        currentState.OnStateEnter();
    }

    public void ChangeDirection()
    {
        move = Vector3.Normalize(new Vector3(moveDir.x, 0.0f, moveDir.y) * Time.deltaTime * movementSpeedMultiplier);
        if (Hypotenuse(moveDir.x, moveDir.y) >= movementInputForDashDirThreshhold)
        {
            moveLastDir = moveDir;
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
        Physics.IgnoreLayerCollision(gameObject.layer, UnequippedLayer, false);
    }

    public void PickupItem(GameObject weaponObject)
    {
        weapon = weaponObject;

        Physics.IgnoreCollision(col, weapon.GetComponent<Collider>(), true);
        Physics.IgnoreLayerCollision(gameObject.layer, UnequippedLayer, true);
    }

    public void OnHit(float damage)
    {
        audioPlayer.PlayerHurting();
        currentState.TakeDamage(damage);
    }
    public void Die()
    {
        currentState.ChangeState(deadState);
    }

    private float Hypotenuse(float sideA, float sideB)
    {
        return Mathf.Sqrt(sideA * sideA + sideB * sideB);
    }

    private void StateUpdateObserver()
    {
        if(stateChangeObserver != currentState)
        {
            stateChangeObserver = currentState;
            if (stateChangeObserver == idleState)
            {
                //spelaren gick precis in i idleState
            }
            if (stateChangeObserver == basicState)
            {
                //spelaren gick precis in i "MoveState"
            }
            if(stateChangeObserver == dashState)
            {
                //Spelaren gick precis in i dashState
            }
            if (stateChangeObserver == throwState)
            {
                //Spelaren gick precis in i throwState
                Debug.Log("player entered throwstate");
            }
            if (stateChangeObserver == attackState)
            {
                //Spelaren gick precis in i attackState
                
            }
        }
    }
}
