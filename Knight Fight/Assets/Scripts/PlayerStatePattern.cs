using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerStatePattern : MonoBehaviour
{
    public PlayerIState currentState;
    [HideInInspector] public PlayerBasicState basicState;
    [HideInInspector] public PlayerDashState dashState;
    [HideInInspector] public PlayerAttackState attackState;
    public  float globalCD = 0.5f;
    public  float internalGCDTimer = 0.0f;
    public  float movementSpeedMultiplier = 35.0f;
    public  float dashDistance = 10f;

    PlayerControls playerControls;
    Vector2 moveDir;
    Vector3 m;

    private void Awake()
    {
        basicState = new PlayerBasicState(this);
        dashState = new PlayerDashState(this);
        
        playerControls = new PlayerControls();
        playerControls.Gameplay.Move.performed += ctx => moveDir = ctx.ReadValue<Vector2>();
        playerControls.Gameplay.Move.canceled += ctx => moveDir = Vector2.zero;
        playerControls.Gameplay.Dash.performed += ctx => currentState.ChangeState(dashState);

    }
    private void Start()
    {
        currentState = basicState;
    }
    private void Update()
    {
        if (internalGCDTimer < globalCD)
        {
            internalGCDTimer += Time.deltaTime;
        }
        currentState.UpdateState();
    }

    public void Movement()
    {
        m = new Vector3(moveDir.x, 0.0f, moveDir.y) * Time.deltaTime * movementSpeedMultiplier;
        transform.Translate(m, Space.World);
    }

    public void Dash()
    {
        transform.position += m * dashDistance;
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
