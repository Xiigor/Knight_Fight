using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicStartTest : MonoBehaviour
{
    public StudioEventEmitter gameplayMusic;
    void Awake()
    {
        gameplayMusic.Play();
    }
}
