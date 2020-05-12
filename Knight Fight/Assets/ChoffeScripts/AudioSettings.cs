using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    public Slider masterVolume;
    public TextMeshProUGUI masterVolumeText;

    public Slider sfxVolume;
    public TextMeshProUGUI sfxVolumeText;

    public Slider musicVolume;
    public TextMeshProUGUI musicVolumeText;

    public Slider commentatorVolume;
    public TextMeshProUGUI commentatorVolumeText;

    public Slider crowdVolume;
    public TextMeshProUGUI crowdVolumeText;

    [Range(0.001f,1f)] public float test = 0.5f;

    private void Start()
    {

    }

    public void ChangeMaster(float change)
    {
        masterVolume.value = change;
        //ändra fmod inställningen
        SetPercentage(masterVolume.value, masterVolumeText);
    }

    public void ChangeSFX(float change)
    {
        sfxVolume.value = change;
        SetPercentage(sfxVolume.value, sfxVolumeText);
    }

    public void ChangeMusic(float change)
    {
        musicVolume.value = change;
        SetPercentage(musicVolume.value, musicVolumeText);
    }

    public void ChangeCommentator(float change)
    {
        commentatorVolume.value = change;
        SetPercentage(commentatorVolume.value, commentatorVolumeText);
    }

    public void ChangeCrowd(float change)
    {
        crowdVolume.value = change;
        SetPercentage(crowdVolume.value, crowdVolumeText);
    }

    public void SetPercentage(float value, TextMeshProUGUI text)
    {
        
        text.text = Mathf.RoundToInt(value) + "%";
    }
}
