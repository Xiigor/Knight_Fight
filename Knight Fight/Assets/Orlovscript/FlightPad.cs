using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPad : MonoBehaviour
{

    private bool setFlight;
    private GameObject[] flyingObjects = new GameObject[4];
    private uint currentlyFlyingObjects;
    private float flightTime;
    private void Update()
    {
        for (int i = 0; i < currentlyFlyingObjects; i++)
        {
            flyingObjects[i].transform.position = Vector3.MoveTowards(flyingObjects[i].transform.position, new Vector3(-29, 700, 458),10000 * Time.deltaTime);

        }
        flightTime -= Time.deltaTime;
        if(flightTime <= 0 && setFlight)
        {
            flyingObjects[currentlyFlyingObjects] = null;
            currentlyFlyingObjects--;
            setFlight = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           
            flightTime = 0.1f;
            flyingObjects[currentlyFlyingObjects] = other.gameObject;
            currentlyFlyingObjects++;
            setFlight = true;
        }
    }
}
