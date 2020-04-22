using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GameplayMusicScript : MonoBehaviour
{
    public StudioEventEmitter gameplayMusic;
    public string paraName;
    
    void Awake()
    {
        gameplayMusic.Play();
    }
}
