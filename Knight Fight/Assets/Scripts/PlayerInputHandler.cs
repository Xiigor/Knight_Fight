using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    //private PlayerInput playerInput;
    private PlayerConfiguration playerConfig;
    private PlayerMover mover;

    [SerializeField]
    private MeshRenderer playerMesh;

    private PlayerControls controls;
    private void Awake()
    {
        mover = GetComponent<PlayerMover>();  //Assign the right mover to the current playerInputHandler that gets "spawned".
        controls = new PlayerControls();

        //Gets our PlayerMover object
    }

    //Lets the player change color
    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        playerMesh.material = pc.PlayerMaterial;
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;    //Using onActionTriggered because we use C# events
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.PlayerMovement.MovementForGamepad.name) //MovementForGamepad can be changed depending on the name for Actions in Input Actions
        {
            OnMove(obj);
        }
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
