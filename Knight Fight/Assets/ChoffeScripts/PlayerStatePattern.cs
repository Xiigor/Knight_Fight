using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatePattern : MonoBehaviour
{
    public PlayerIState currentState;
    private PlayerIState stateChangeObserver;
    //IdleState ?? 
    [HideInInspector] public PlayerBasicState basicState;
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


    public float movementSpeedMultiplier = 35.0f;

    public float dashDuration = 0.1f;
    public float dashSpeed = 500.0f;
    [Range(0.0f, 1.0f)] public float movementInputForDashDirThreshhold = 0.25f;
    public float internalDashRayDist = 1.3f;
    public bool canDash = true;

    public GameObject weapon;
    public string weaponTag = "Weapon";
    public string projectileTag = "Projectile";
    public string environmentTag = "Environment";

    [HideInInspector] public Vector2 moveDir;
    Vector2 moveLastDir;
    Vector3 move;
    public Vector3 lastMove;
    public float maxHealth = 100f;
    public float health;
    [HideInInspector] public Collider col;
    [HideInInspector] List<Collider> ignoredColliders;
    private Rigidbody rb;


    [SerializeField] private int playerIndex;


    private void Awake()
    {
        health = maxHealth;
        basicState = new PlayerBasicState(this);

        currentState = stateChangeObserver = basicState;
        dashState = new PlayerDashState(this);
        throwState = new PlayerThrowState(this);
        deadState = new PlayerDeadState(this);
        attackState = new PlayerAttackState(this);
        col = GetComponent<Collider>();
        ignoredColliders = new List<Collider>();
        rb = GetComponent<Rigidbody>();
        internalGCDTimer = globalCD;
        internalDashTimer = dashCD;  

    }

    private void FixedUpdate()
    {
        StateUpdateObserver();
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
        if(health <= 0)
        {
            currentState.ChangeState(deadState);
        }
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
        // Ifall spelaren håller i ett vapen så läggs alla andra vapen hen går över till i en lista av ignorerade colliders, listan clearas när spelaren kastar sitt vapen
        if (collision.gameObject.tag == projectileTag)
        {
            OnHit(collision.gameObject.GetComponent<WeaponBaseClass>().thrownDamage);
            Debug.Log(gameObject.name + "Hit by wep in projectile state!!");
        }
        
        if (collision.gameObject.tag == weaponTag && weapon != null)
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), col, true);
            ignoredColliders.Add(collision.gameObject.GetComponent<Collider>());

        }
        // kanske måste lägga till att ignorera vapen
        if (currentState == dashState)
        {
            currentState.ChangeState(basicState);
        }
    }
    public void Attack()
    {
        if(weapon != null)
        {
           if(weapon.GetComponent<WeaponSwordPattern>())
            {
                Debug.Log("Attacks with sword");
            }
        }
        else
        {
            //do basic punch attack.
        }
    }

    public void RestoreIgnoredColliders()
    {
        if(ignoredColliders.Count != 0)
        {
            foreach (Collider igC in ignoredColliders)
            {
                Physics.IgnoreCollision(igC, col, false);
            }
            ignoredColliders.Clear();
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

    public void Movement()
    {
        move = new Vector3(moveDir.x, 0.0f, moveDir.y) * Time.deltaTime * movementSpeedMultiplier;
        lastMove = new Vector3(moveLastDir.x, 0.0f, moveLastDir.y) * Time.deltaTime * movementSpeedMultiplier;
        if (Hypotenuse(moveDir.x, moveDir.y) >= movementInputForDashDirThreshhold)
        {
            moveLastDir = moveDir;
        }
        //transform.Translate(move, Space.World);
        rb.velocity = move * movementSpeedMultiplier;
        
        transform.forward = lastMove;
    }

    public void Dash()
    {
        transform.Translate(lastMove * dashSpeed * Time.deltaTime, Space.World);
    }

    public void ThrowItem()
    {
            weapon.GetComponent<WeaponBaseClass>().ThrowWep();
    }

    public void OnHit(float damage)
    {
        currentState.TakeDamage(damage);
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
            if(stateChangeObserver == basicState)
            {
                //spelaren gick precis in i basicState
                Debug.Log("basicState");
            }
            if(stateChangeObserver == dashState)
            {
                //Spelaren gick precis in i dashState
                Debug.Log("Dashstate");
            }
            if (stateChangeObserver == throwState)
            {
                //Spelaren gick precis in i throwState
                Debug.Log("throwstate");
            }
        }
    }
}
