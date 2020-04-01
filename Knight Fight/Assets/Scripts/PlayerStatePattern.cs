using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerStatePattern : MonoBehaviour
{
    [HideInInspector] public PlayerIState currentState;
    [HideInInspector] public PlayerBasicState basicState;
    [HideInInspector] public PlayerDashState dashState;
    [HideInInspector] public Rigidbody rb;
    public  float globalCD = 0.5f;
    public  float internalGCDTimer = 0.0f;
    public float attackStateDuration;
    public float dashStateDuration;
    public  float movementSpeedMultiplier;
    public  float dashDistance = 20f;

    PlayerControls playerControls;
    Vector3 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        basicState = new PlayerBasicState(this);
        
        playerControls = new PlayerControls();
        playerControls.Gameplay.Move.performed += ctx => moveDir = ctx.ReadValue<Vector2>();
        playerControls.Gameplay.Move.canceled += ctx => moveDir = Vector2.zero;
        playerControls.Gameplay.Dash.performed += ctx => currentState = dashState;
    }
    private void Start()
    {
        currentState = basicState;
    }
    private void Update()
    {
        if (internalGCDTimer > globalCD)
        {
            currentState.UpdateState();
        }
        else
            internalGCDTimer += Time.deltaTime;
    }
    public void Movement()
    {
        Vector3 m = new Vector3(moveDir.x, 0.0f, moveDir.y) * Time.deltaTime * movementSpeedMultiplier;
        transform.Translate(m, Space.World);
    }

    public void Dash()
    {

    }

    private void OnEnable()
    {
        playerControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerControls.Gameplay.Disable();
    }
}
