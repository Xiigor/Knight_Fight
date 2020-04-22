using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class GameplayMusicScript : MonoBehaviour
{
    public StudioEventEmitter gameplayMusic;
    public string ParaName;
 
    private void Awake()
    {
        gameplayMusic.Play();
    }

    void Start()
    {
        GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("Found Player");
    }
    

    

}
