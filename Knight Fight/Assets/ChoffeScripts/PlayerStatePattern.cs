using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerStatePattern : MonoBehaviour
{
    //ITEMS SOM Blir kastade plockas direkt upp av spelaren igen eftersom deras colliders överlappar... det är ju inte jättebra
    //Fix next session men man kan iaf se i loggen att items kastas och man bör kunna lägga in ljud för det.

    public PlayerIState currentState;
    private PlayerIState stateChangeObserver;
    [HideInInspector] public PlayerBasicState basicState;
    [HideInInspector] public PlayerDashState dashState;
    [HideInInspector] public PlayerThrowState throwState;
    [HideInInspector] public PlayerAttackState attackState;

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

    public float throwStrength = 10f;
    public float throwAnimDuration = 0.2f;

    public GameObject currentWeapon = null;
    private WeaponPickup currentWepScript = null;
    public Transform handChild;

    public string weaponTag = "Weapon";
    public string environmentTag = "Environment";

    PlayerControls playerControls;
    [HideInInspector] public Vector2 moveDir;
    Vector2 moveLastDir;
    Vector3 move;
    Vector3 lastMove;

    private void Awake()
    {
        basicState = new PlayerBasicState(this);
        dashState = new PlayerDashState(this);
        throwState = new PlayerThrowState(this);
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
        if(collision.gameObject.tag == weaponTag)
        {
            PickUpItem(collision);
        }
        else if(currentState == dashState)
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
                if(currentWeapon != null)
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

    public void PickUpItem(Collision other)
    {
        currentWeapon = other.gameObject;
        currentWepScript = currentWeapon.GetComponent<WeaponPickup>();
        //fungerar tillsvidare
        currentWeapon.transform.SetParent(handChild);
        currentWepScript.SetParent();
        currentWepScript.SetPos();
    }

    public void ThrowItem()
    {
        Debug.Log("throwitem function trigger");
        currentWeapon.transform.parent = null;
        currentWepScript.RemoveParent();
        currentWepScript.rb.AddForce(moveLastDir * throwStrength);
        currentWeapon = null;
        currentWepScript = null;
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
