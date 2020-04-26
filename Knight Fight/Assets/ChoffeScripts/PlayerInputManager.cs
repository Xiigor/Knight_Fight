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
    private List<InputDevice> inputDevices;
    public List<PlayerInput> inputHandlers;

    private void Start()
    {
        inputDevices = new List<InputDevice>();
        inputHandlers = new List<PlayerInput>();
        foreach (InputDevice index in InputDevice.all)
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
            inputHandlers.Add(player1InputHandler);
        }
        if (player2 == true && player2InputHandler == null)
        {
            player2InputHandler = PlayerInput.Instantiate(inputHandlerPrefab, 1, null, 1, inputDevices[1].device);
            inputHandlers.Add(player2InputHandler);
        }
        if (player3 == true && player3InputHandler == null)
        {
            player3InputHandler = PlayerInput.Instantiate(inputHandlerPrefab, 0, null, 1, inputDevices[0].device);
            inputHandlers.Add(player3InputHandler);
        }
        if (player4 == true && player4InputHandler == null)
        {
            player4InputHandler = PlayerInput.Instantiate(inputHandlerPrefab, 0, null, 1, inputDevices[0].device);
            inputHandlers.Add(player4InputHandler);
        }

    }
}
