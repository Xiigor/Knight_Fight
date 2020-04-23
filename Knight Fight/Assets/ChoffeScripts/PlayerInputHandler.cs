﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerStatePattern playerStatePattern;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var playerStatePatterns = FindObjectsOfType<PlayerStatePattern>();
       
        var index = playerInput.playerIndex;
        playerStatePattern = playerStatePatterns.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }
    public void OnMove(CallbackContext context)
    {
        if(playerStatePattern != null)
        {
            playerStatePattern.moveDir = context.ReadValue<Vector2>();
        }
        
    }
    public void OnDash(CallbackContext context)
    {
        if (playerStatePattern != null)
        {
            if (context.performed)
            {
                playerStatePattern.currentState.ChangeState(playerStatePattern.dashState);
            }
            
        }
        
    }
    public void OnThrowWep(CallbackContext context)
    {
        if (playerStatePattern != null)
        {
            if (context.performed)
            {
                playerStatePattern.currentState.ChangeState(playerStatePattern.throwState);
            }    
        }
        
    }
    public void OnAttack(CallbackContext context)
    {
        if (playerStatePattern != null)
        {
            if (context.performed)
            {
                playerStatePattern.currentState.ChangeState(playerStatePattern.attackState);
            }  
        }
    }
}
