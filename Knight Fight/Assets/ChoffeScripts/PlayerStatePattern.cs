using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerStatePattern : MonoBehaviour
{
    public PlayerIState currentState;
    private PlayerIState stateChangeObserver;
    [HideInInspector] public PlayerBasicState basicState;
    [HideInInspector] public PlayerDashState dashState;
    [HideInInspector] public PlayerThrowState throwState;
    [HideInInspector] public PlayerAttackState attackState;
    [HideInInspector] public PlayerDeadState deadState;

    public  float globalCD = 0.5f;
    public float dashCD = 0.2f;
    [HideInInspector]  public  float internalGCDTimer;
    [HideInInspector] public float internalDashTimer;   
    

    public float movementSpeedMultiplier = 35.0f;

    public float dashDuration = 0.1f;
    public float dashSpeed = 500.0f;
    [Range(0.0f, 1.0f)] public float movementInputForDashDirThreshhold = 0.25f;
    private float internalDashRayDist = 1.1f;
    public bool canDash = true;

    public float throwAnimDuration = 0.2f;

    public GameObject weapon;
    public string weaponTag = "Weapon";

    public string environmentTag = "Environment";

    PlayerControls playerControls;
    [HideInInspector] public Vector2 moveDir;
    Vector2 moveLastDir;
    Vector3 move;
    Vector3 lastMove;
    public float maxHealth = 100f;
    [HideInInspector] public float health;

    private void Awake()
    {
        health = maxHealth;
        basicState = new PlayerBasicState(this);
        dashState = new PlayerDashState(this);
        throwState = new PlayerThrowState(this);
        deadState = new PlayerDeadState(this);
        internalGCDTimer = globalCD;
        internalDashTimer = dashCD;

        
        playerControls = new PlayerControls();
        playerControls.Gameplay.Move.performed += ctx => moveDir  = ctx.ReadValue<Vector2>();
        playerControls.Gameplay.Move.canceled += ctx => moveDir = Vector2.zero;
        playerControls.Gameplay.Dash.performed += ctx => currentState.ChangeState(dashState);
        playerControls.Gameplay.ThrowWep.performed += ctx => currentState.ChangeState(throwState);
    }
    private void Start()
    {
        currentState = stateChangeObserver = basicState;
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
        if(health <= 0)
        {
            currentState.ChangeState(deadState);
        }
        if(Hypotenuse(moveDir.x, moveDir.y) >= movementInputForDashDirThreshhold)
        {
            moveLastDir = moveDir;
        }
        if (internalGCDTimer < globalCD)
        {
            internalGCDTimer += Time.deltaTime;
        }
        if (internalDashTimer < dashCD)
        {
            internalDashTimer += Time.deltaTime;
        }
        StateUpdateObserver();
        currentState.UpdateState();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentState == dashState)
        {
            currentState.ChangeState(basicState);
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
        transform.Translate(move, Space.World);
        transform.forward = lastMove;
    }

    public void Dash()
    {
        transform.position += lastMove * dashSpeed *Time.deltaTime;
    }

    public void ThrowItem()
    {
            weapon.GetComponent<WeaponPickup>().Throw();
            weapon = null;
    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
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
