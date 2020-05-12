using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGameplayState : GameIState
{
    private readonly GameManager manager;
    public GameGameplayState(GameManager gameManager)
    {
        manager = gameManager;
    }
    public void OnStateEnter()
    {
        manager.audioManager.StartGameplayMusic();
        manager.AddPlayersForCamera();
        manager.cameraScript.ChangeState(manager.cameraScript.battleViewState);
        manager.menuCanvas.gameObject.SetActive(false);
        manager.inputManagerScript.trigger = true;
    }

    public void UpdateState()
    {
        manager.weaponSpawnManager.TimerUpdater();
        manager.CheckForWinner();
    }
}
