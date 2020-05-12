﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputSystem.InputAction;

public class GameManager : MonoBehaviour
{
    //statemachine objects
    public GameIState gameState;
    public GameGameplayState gameplayState;
    public GameMenuState menuState;
    public GameWinState winState;

    //lists used by the gamemanager
    //private List<Gamepad> inputDevices;
    private List<InputDevice> inputDevices;
    public List<GameObject> readyPlayers;
    public List<GameObject> alivePlayers;

    //components and scripts
    public GameObject cameraObject;
    public Canvas menuCanvas;
    public GameObject gameMenu;
    [HideInInspector]public CameraStatePattern cameraScript;
    public GameObject inputManagerObject;
    [HideInInspector]public PlayerInputManager inputManagerScript;
    public AudioMenu audioManager;
    public WeaponSpawnManager weaponSpawnManager;

    //rounds
    public int amountOfRounds = 1;
    public TextMeshProUGUI roundsText;
    [HideInInspector] public GameObject roundWinner;
    [HideInInspector] public bool newRoundProcessStarted = false;

    //durations
    public float winStateDuration = 5f;
    public float newRoundDelayDuration = 2f;
    public float internalRoundDelayTimer = 0f;

    //player related components
    public GameObject player1;
    public GameObject player1Ready;
    public GameObject player1NotReady;

    public GameObject player2;
    public GameObject player2Ready;
    public GameObject player2NotReady;

    public GameObject player3;
    public GameObject player3Ready;
    public GameObject player3NotReady;

    public GameObject player4;
    public GameObject player4Ready;
    public GameObject player4NotReady;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        amountOfRounds = 1;
        gameplayState = new GameGameplayState(this);
        menuState = new GameMenuState(this);
        winState = new GameWinState(this);
        
        cameraScript = cameraObject.GetComponent<CameraStatePattern>();
        inputManagerScript = inputManagerObject.GetComponent<PlayerInputManager>();
        audioManager = GetComponent<AudioMenu>();
        weaponSpawnManager = GetComponent<WeaponSpawnManager>();
        //inputDevices = new List<Gamepad>();
        inputDevices = new List<InputDevice>();
        readyPlayers = new List<GameObject>();
        ToMenu();

        //foreach (Gamepad index in Gamepad.all)
        //    inputDevices.Add(index);
        foreach (InputDevice index in InputSystem.devices)
        {
            inputDevices.Add(index);
        }
    }

    public void Update()
    {
        Debug.Log(gameState);
        gameState.UpdateState();
        SetRoundsText();
    }

    public void OnStart()
    {
        if(readyPlayers.Count >= 1)
        {
            alivePlayers.Clear();
            foreach(GameObject player in readyPlayers)
            {
                alivePlayers.Add(player);
            }
            audioManager.StartPressed();
            gameState = gameplayState;
            gameState.OnStateEnter();
        }
    }

    public void OnExit()
    {
        audioManager.ButtonPressed();
        Application.Quit();
    }

    public void SpawnPlayers()
    {
        inputManagerScript.trigger = true;
    }

    public void OnJoin(CallbackContext context)
    {
        if (gameState == menuState && gameMenu.active)
        {
            if(context.control.device == inputDevices[0])
            {
                if (!readyPlayers.Contains(player1))
                {
                    audioManager.PlayerJoined();
                    player1NotReady.SetActive(false);
                    player1Ready.SetActive(true);
                    inputManagerScript.player1 = true;
                    readyPlayers.Add(player1);
                }
            }
            else if (context.control.device == inputDevices[1])
            {
                if (!readyPlayers.Contains(player2))
                {
                    audioManager.PlayerJoined();
                    player2NotReady.SetActive(false);
                    player2Ready.SetActive(true);
                    inputManagerScript.player2 = true;
                    readyPlayers.Add(player2);
                }

            }
            else if (context.control.device == inputDevices[2])
            {
                if (!readyPlayers.Contains(player3))
                {
                    audioManager.PlayerJoined();
                    player3NotReady.SetActive(false);
                    player3Ready.SetActive(true);
                    inputManagerScript.player3 = true;
                    readyPlayers.Add(player3);
                }

            }
            else if (context.control.device == inputDevices[3])
            {
                if (!readyPlayers.Contains(player4))
                {
                    audioManager.PlayerJoined();
                    player4NotReady.SetActive(false);
                    player4Ready.SetActive(true);
                    inputManagerScript.player4 = true;
                    readyPlayers.Add(player4);
                }

            }
        }
 
    }

    public void OnLeave(CallbackContext context)
    {
        if (gameState == menuState && gameMenu.active)
        {
            if (context.control.device == inputDevices[0])
            {
                if (readyPlayers.Contains(player1))
                {
                    audioManager.PlayerLeft();
                    player1NotReady.SetActive(true);
                    player1Ready.SetActive(false);
                    inputManagerScript.player1 = false;
                    readyPlayers.Remove(player1);
                }

            }
            else if (context.control.device == inputDevices[1])
            {
                if (readyPlayers.Contains(player2))
                {
                    audioManager.PlayerLeft();
                    player2NotReady.SetActive(true);
                    player2Ready.SetActive(false);
                    inputManagerScript.player2 = false;
                    readyPlayers.Remove(player2);
                }

            }
            else if (context.control.device == inputDevices[2])
            {
                if (readyPlayers.Contains(player3))
                {
                    audioManager.PlayerLeft();
                    player3NotReady.SetActive(true);
                    player3Ready.SetActive(false);
                    inputManagerScript.player3 = false;
                    readyPlayers.Remove(player3);
                }

            }
            else if (context.control.device == inputDevices[3])
            {
                if (readyPlayers.Contains(player4))
                {
                    audioManager.PlayerLeft();
                    player4NotReady.SetActive(true);
                    player4Ready.SetActive(false);
                    inputManagerScript.player4 = false;
                    readyPlayers.Remove(player4);
                }
            }
        }
    }

    public void AddPlayersForCamera()
    {
        cameraScript.objectsFollowedByCamera.Clear();
        foreach (GameObject player in readyPlayers)
        {
            cameraScript.objectsFollowedByCamera.Add(player.transform);
        }
    }
    public void RemovePlayersForCamera()
    {
        readyPlayers.Clear();
        alivePlayers.Clear();
        cameraScript.objectsFollowedByCamera.Clear();
    }
    public void EnablePlayers()
    {
        foreach(GameObject player in readyPlayers)
        {
            player.SetActive(true);
        }
    }
    public void DisablePlayers()
    {
        foreach (GameObject player in readyPlayers)
        {
            player.SetActive(false);
        }
    }
    public void ToMenu()
    {
        if (gameState != menuState)
        {
            gameState = menuState;
            gameState.OnStateEnter();
        }
    }
    public void CheckForRoundWinner()
    {
        if(alivePlayers.Count == 1)
        {
            newRoundProcessStarted = true;
            foreach(GameObject player in alivePlayers)
            {
                roundWinner = player;
                player.GetComponent<PlayerScoreTracker>().IncrementScore();
            }
            
            //CheckForWinner();

        }
    }
    public void CheckForWinner()
    {
        //if roundwinner score == amount of rounds in game
        if (roundWinner.GetComponent<PlayerScoreTracker>().score == amountOfRounds)
        {
            gameState = winState;
            gameState.OnStateEnter();
        }
        else
        {
            OnStart();
        }
    }
    public void IncrementRounds()
    {
        amountOfRounds += 1;
    }
    public void DecrementRounds()
    {
        if(amountOfRounds > 1)
        {
            amountOfRounds -= 1;
        }
    }
    public void SetRoundsText()
    {
        roundsText.text = amountOfRounds.ToString();
    }
}
