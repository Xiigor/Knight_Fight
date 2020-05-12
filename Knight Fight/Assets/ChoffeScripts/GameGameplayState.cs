using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameGameplayState : GameIState
{
    private CounterManager cm;
    private CountdownTimer countdown;
    private readonly GameManager manager;

    public GameGameplayState(GameManager gameManager)
    {
        manager = gameManager;
        cm = GameObject.Find("GameManager").GetComponent<CounterManager>();
        countdown = GameObject.Find("CountdownTimer").GetComponent<CountdownTimer>();
        countdown.gameObject.SetActive(false);
    }
    public void OnStateEnter()
    {
        //disable players here and enable again after countdown == easy fix for many rounds
        manager.DisablePlayers();
        manager.AddPlayersForCamera();
        manager.cameraScript.ChangeState(manager.cameraScript.battleViewState);
        manager.audioManager.StartGameplayMusic();

        manager.weaponSpawnManager.DestroyWeapons();
        countdown.ResetTimer();
        manager.internalRoundDelayTimer = 0f;
        countdown.counting = true;
        manager.menuCanvas.gameObject.SetActive(false);
        manager.newRoundProcessStarted = false;
      
    }

    public void UpdateState()
    {
        if (cm.countdownIsDone == true)
        {
            manager.EnablePlayers();
            manager.inputManagerScript.trigger = true;
            cm.countdownIsDone = false;

        }
        manager.weaponSpawnManager.TimerUpdater();

        if(manager.newRoundProcessStarted == false)
        {
            manager.CheckForRoundWinner();
        }
        if (manager.newRoundProcessStarted)
        {
            manager.internalRoundDelayTimer += Time.deltaTime;
        }
        if (manager.internalRoundDelayTimer >= manager.newRoundDelayDuration)
        {
            manager.CheckForWinner();
        }
    }
}
