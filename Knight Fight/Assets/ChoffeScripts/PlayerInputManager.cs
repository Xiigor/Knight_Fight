using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputManager : MonoBehaviour
{
    public GameObject inputHandlerPrefab;
    public bool player1;
    private PlayerInput player1InputHandler = null;
    public bool player2;
    private PlayerInput player2InputHandler = null;
    public bool player3;
    private PlayerInput player3InputHandler = null;
    public bool player4;
    private PlayerInput player4InputHandler = null;
    public bool trigger;
    public bool triggered;
    private List<Gamepad> inputDevices;
    private List<GameObject> inputHandlers;

    private void Start()
    {
        inputDevices = new List<Gamepad>();
        inputHandlers = new List<GameObject>();
        foreach (Gamepad index in Gamepad.all)
            inputDevices.Add(index);
    }

    private void Update()
    {
        if (trigger)
        {
            if (!triggered)
            {
                SpawnPlayers();
                triggered = true;
            }
            
        }
    }

    public void SpawnPlayers()
    {
        if (player1 == true && player1InputHandler == null)
        {
            player1InputHandler = PlayerInput.Instantiate(inputHandlerPrefab, 0, null,1, inputDevices[0].device);
            
        }
        if (player2)
        {
            player2InputHandler = PlayerInput.Instantiate(inputHandlerPrefab, 1, null, 1, inputDevices[1].device);
        }

    }
}
