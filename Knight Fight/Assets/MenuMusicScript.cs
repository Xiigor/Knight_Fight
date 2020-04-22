using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class MenuMusicScript : MonoBehaviour
{
    public StudioEventEmitter menuMusic;

    private void Awake()
    {
        menuMusic.Play();
    }


}
