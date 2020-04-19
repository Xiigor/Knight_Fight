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
    public string playerHurt;
    public FMOD.Studio.EventInstance playerHurting;

    [EventRef]
    public string playerHurtMale;
    public FMOD.Studio.EventInstance playerHurtingMale;

    [EventRef]
    public string playerHurtFemale;
    public FMOD.Studio.EventInstance playerHurtingFemale;

//<<<<<<< HEAD
    [EventRef]
    public string playerAttack;
    public FMOD.Studio.EventInstance playerAttacking;
//=======
    //[EventRef]
    //public string playerAttack;
    //public FMOD.Studio.EventInstance playerAttacking;
//>>>>>>> Ljud-Erik

    [EventRef]
    public string playerDash;
    public FMOD.Studio.EventInstance playerDashing;

    [EventRef]
    public string playerThrow;
    public FMOD.Studio.EventInstance playerThrowing;

//<<<<<<< HEAD
    [EventRef]
    public string playerThrowMale;
    public FMOD.Studio.EventInstance playerThrowingMale;
//=======
    //[EventRef]
    //public string playerThrowMale;
    //public FMOD.Studio.EventInstance playerThrowingMale;
//>>>>>>> Ljud-Erik



    public void PlayerThrowing()
    {
        Debug.Log("Player throwing sound");
//<<<<<<< HEAD
        //playerThrowing = RuntimeManager.CreateInstance(playerThrow);
        //RuntimeManager.PlayOneShot(playerThrow, transform.position);
        //playerThrowing.start();
//=======
        playerThrowing = RuntimeManager.CreateInstance(playerThrow);
        RuntimeManager.PlayOneShot(playerThrow, transform.position);
        playerThrowing.start();
//>>>>>>> Ljud-Erik
    }

    public void PlayerDashing()
    {
        Debug.Log("Player dashing sound");
//<<<<<<< HEAD
        //playerDashing = RuntimeManager.CreateInstance(playerDash);
        //RuntimeManager.PlayOneShot(playerDash, transform.position);
        //playerDashing.start();
    }

    public void PlayerAttacking() // ------- Tror inte denna funktion behövs eftersom vapnena själva håller kolla på sina ljud
    {
        
        Debug.Log("Player Attacking sound");
        //playerAttacking = RuntimeManager.CreateInstance(playerAttack);
        //RuntimeManager.PlayOneShot(playerAttack, transform.position);
        //playerAttacking.start();
    }

    public void PlayerHurting() //Spelar alla vapenljud för female ???
//=======
        playerDashing = RuntimeManager.CreateInstance(playerDash);
        RuntimeManager.PlayOneShot(playerDash, transform.position);
        playerDashing.start();
    }

    

    public void PlayerHurting()
//>>>>>>> Ljud-Erik
    {
        if(givenGender == 0)
        {
            PlayerHurtingFemale();
        }
        else
        {
            PlayerHurtingMale();
        }
//<<<<<<< HEAD
        //playerHurting = RuntimeManager.CreateInstance(playerHurt);
        //RuntimeManager.PlayOneShot(playerHurt, transform.position);
        //playerHurting.start();
//=======
        playerHurting = RuntimeManager.CreateInstance(playerHurt);
        RuntimeManager.PlayOneShot(playerHurt, transform.position);
        playerHurting.start();
//>>>>>>> Ljud-Erik
    }
    private void PlayerHurtingMale() //Spelar alla vapenljud för male
    {
        Debug.Log("MalePlayer got hurt");
//<<<<<<< HEAD
        //playerHurtingMale = RuntimeManager.CreateInstance(playerHurtMale);
        //RuntimeManager.PlayOneShot(playerHurtMale, transform.position);
        //playerHurtingMale.start();
//=======
        playerHurtingMale = RuntimeManager.CreateInstance(playerHurtMale);
        RuntimeManager.PlayOneShot(playerHurtMale, transform.position);
        playerHurtingMale.start();
//>>>>>>> Ljud-Erik
    }
    private void PlayerHurtingFemale() //Spelar alla vapenljud för female
    {
        Debug.Log("femalePlayer got hurt");
//<<<<<<< HEAD
        //playerHurtingMale = RuntimeManager.CreateInstance(playerHurtFemale);
        //RuntimeManager.PlayOneShot(playerHurtFemale, transform.position);
        //playerHurtingFemale.start();
//=======
       playerHurtingMale = RuntimeManager.CreateInstance(playerHurtFemale);
       RuntimeManager.PlayOneShot(playerHurtFemale, transform.position);
       playerHurtingFemale.start();
//>>>>>>> Ljud-Erik
    }
}
