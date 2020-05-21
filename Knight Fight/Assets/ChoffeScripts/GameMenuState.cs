using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : GameIState
{
    private readonly GameManager manager;

    public GameMenuState(GameManager gameManager)
    {
        manager = gameManager;
    }

    public void OnStateEnter()
    {
        foreach (GameObject player in manager.readyPlayers)
        {
            player.GetComponent<PlayerScoreTracker>().ClearScore();
        }
        manager.DisablePlayers();
        manager.crowdMoodSetter.SetMood(0);
        manager.weaponSpawnManager.DestroyWeapons();
        manager.audioManager.StartMenuMusic();
        manager.cameraScript.ChangeState(manager.cameraScript.arenaViewState);
        manager.menuCanvas.gameObject.SetActive(true);

        manager.player1NotReady.SetActive(true);
        manager.player2NotReady.SetActive(true);
        manager.player3NotReady.SetActive(true);
        manager.player4NotReady.SetActive(true);

        manager.player1Ready.SetActive(false);
        manager.player2Ready.SetActive(false);
        manager.player3Ready.SetActive(false);
        manager.player4Ready.SetActive(false);

        manager.inputManagerScript.trigger = false;
        manager.inputManagerScript.triggered = false;
        manager.RemovePlayersForCamera();

    }

    public void UpdateState()
    {
        manager.SetRoundsText();
    }
}
