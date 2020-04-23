using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputManager2 : MonoBehaviour
{
    public GameObject inputHandlerPrefab;
    public bool player1;
    public GameObject player1Object;
    public bool player2;
    public GameObject player2Object;
    public bool player3;
    public GameObject player3Object;
    public bool player4;
    public GameObject player4Object;
    public bool trigger;
    public bool triggered;
    private List<Gamepad> inputDevices;

    private void Start()
    {
        inputDevices = new List<Gamepad>();
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
        if (player1)
        {
            player1Object.gameObject.SetActive(true);
            PlayerInput.Instantiate(inputHandlerPrefab, 0, null,1, inputDevices[0].device);
        }
        if (player2)
        {
            player2Object.gameObject.SetActive(true);
            PlayerInput.Instantiate(inputHandlerPrefab, 1, null, 1, inputDevices[1].device);
        }

    }
}
