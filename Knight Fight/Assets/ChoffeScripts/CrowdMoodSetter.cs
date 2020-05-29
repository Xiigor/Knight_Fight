using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class CrowdMoodSetter : MonoBehaviour
{
    public List<GameObject> crowdObjects;
    public GameObject menuObject;




    public void SetMood(int value)
    {
        if(value == 1)
        {
            menuObject.GetComponent<StudioEventEmitter>().EventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            foreach (GameObject crowd in crowdObjects)
            {
                crowd.GetComponent<StudioEventEmitter>().EventInstance.start();
            }
        }
        else if(value == 0)
        {
            menuObject.GetComponent<StudioEventEmitter>().EventInstance.start();
            foreach (GameObject crowd in crowdObjects)
            {
                crowd.GetComponent<StudioEventEmitter>().EventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
    }
}
