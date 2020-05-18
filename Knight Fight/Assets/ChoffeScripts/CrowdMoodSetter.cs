using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class CrowdMoodSetter : MonoBehaviour
{
    public List<GameObject> crowdObjects;

    public void SetMood(int value)
    {
        foreach (GameObject crowd in crowdObjects)
        {
            
            crowd.GetComponent<StudioEventEmitter>().EventInstance.setParameterByName("CrowdMood", value);
        }
    }
}
