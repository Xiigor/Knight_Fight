using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour
{
    // Start is called before the first frame update
    private float teleportTimer;
    private TeleportPad[] pads;
    private GameObject[] players = new GameObject[4];
    private int counter;
    void Start()
    {
        pads = FindObjectsOfType<TeleportPad>();
        teleportTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(teleportTimer);
        teleportTimer -= Time.deltaTime;
        if (teleportTimer < 0)
        {
            for (int i = 0; i < pads.Length; i++)
            {
                if(players[i] != null)
                {
                    if(i + 1 > pads.Length)
                    {
                        i = 0;
                    }
                    players[i].transform.position = new Vector3(pads[i + 1].transform.position.x, players[i].transform.position.y, pads[i + 1].transform.position.z);
                }
               


            }
            teleportTimer = 3;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            counter++;
            if (counter > 4)
            {
                counter = 0;
            }
            players[counter] = other.gameObject;
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            players[counter] = null;
            if (counter < 0)
            {
                counter = 0;
            }
        }
    }
}
