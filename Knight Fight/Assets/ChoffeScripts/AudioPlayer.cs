using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class AudioPlayer : MonoBehaviour
{
    public int givenGender;

    public void OnEnable()
    {
        givenGender = Random.Range(0, 2);
    }

    [EventRef]
    public string playerHurtMale;
    public FMOD.Studio.EventInstance playerHurtingMale;

    [EventRef]
    public string playerHurtFemale;
    public FMOD.Studio.EventInstance playerHurtingFemale;

    [EventRef]
    public string playerDash;
    public FMOD.Studio.EventInstance playerDashing;

    [EventRef]
    public string playerThrow;
    public FMOD.Studio.EventInstance playerThrowing;


    public void PlayerThrowing()
    {
        Debug.Log("Player throwing sound");
        playerThrowing = RuntimeManager.CreateInstance(playerThrow);
        RuntimeManager.PlayOneShot(playerThrow, transform.position);
        playerThrowing.start();
    }

    public void PlayerDashing()
    {
        Debug.Log("Player dashing sound");
        playerDashing = RuntimeManager.CreateInstance(playerDash);
        RuntimeManager.PlayOneShot(playerDash, transform.position);
        playerDashing.start();
    }

    public void PlayerHurting()
    {
        if(givenGender == 0)
        {
            PlayerHurtingFemale();
        }
        else
        {
            PlayerHurtingMale();
        }
    }
    private void PlayerHurtingMale() //Spelar alla vapenljud för male
    {
        Debug.Log("MalePlayer got hurt");
        playerHurtingMale = RuntimeManager.CreateInstance(playerHurtMale);
        RuntimeManager.PlayOneShot(playerHurtMale, transform.position);
        playerHurtingMale.start();
    }
    private void PlayerHurtingFemale() //Spelar alla vapenljud för female
    {
        Debug.Log("femalePlayer got hurt");
        playerHurtingMale = RuntimeManager.CreateInstance(playerHurtFemale);
        RuntimeManager.PlayOneShot(playerHurtFemale, transform.position);
        playerHurtingFemale.start();
    }
}
