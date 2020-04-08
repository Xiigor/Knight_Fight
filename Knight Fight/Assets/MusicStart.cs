using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class MusicStart : MonoBehaviour
{
    public StudioEventEmitter gameplayMusic;

    void Awake()
    {
        gameplayMusic.Play();
    }

}

