using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    portal[] portals;
    private int random;
    private static int count;
    private int number;
    void Start()
    {
        
        count++;
        number = count;
        portals = FindObjectsOfType<portal>();
    }

    void OnCollisionEnter(Collision col)
    {
        random = Random.Range(0, count);
        if(random != count)
        {
            col.gameObject.transform.position = portals[random].transform.position;
        }
        else
        {
            random = Random.Range(0, count);
        }
        



    }
}
