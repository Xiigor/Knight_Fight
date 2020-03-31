using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour 
{
    public float movementSpeedMultiplier = 5.0f;
    PlayerControls controls;
    Vector2 move;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
    }

    private void Update()
    {
        Vector3 m = new Vector3(move.x, 0.0f, move.y) * Time.deltaTime * movementSpeedMultiplier;
        transform.Translate(m, Space.World);
    }
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}
