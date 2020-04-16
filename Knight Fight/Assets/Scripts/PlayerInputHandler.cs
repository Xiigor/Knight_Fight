using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMover mover;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<PlayerMover>();  //Assign the right mover to the current playerInputHandler that gets "spawned".
        var index = playerInput.playerIndex;    //index 0 = player 1, index 1 = player 2 osv


        mover = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
        //Gets our PlayerMover object
        //mover = GetComponent<PlayerMover>();
    }

    public void OnMove(CallbackContext context)
    {
        mover.SetInputVector(context.ReadValue<Vector2>());
    }
    /*
    // Update is called once per frame
    void Update()
    {
        //Checks input in x and y axis, sets the InputVector to the mover
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        mover.SetInputVector(new Vector2(x, y));
    }
    */
}
