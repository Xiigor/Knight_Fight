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
        countdown.ResetTimer();
        countdown.counting = true;
        manager.menuCanvas.gameObject.SetActive(false);
      
    }

    public void UpdateState()
    {
        if (cm.countdownIsDone == true)
        {
            manager.audioManager.StartGameplayMusic();
            manager.AddPlayersForCamera();
            manager.cameraScript.ChangeState(manager.cameraScript.battleViewState);
            manager.inputManagerScript.trigger = true;
            cm.countdownIsDone = false;

        }
        manager.weaponSpawnManager.TimerUpdater();
        manager.CheckForWinner();
    }
}
