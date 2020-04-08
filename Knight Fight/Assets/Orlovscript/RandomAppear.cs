using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAppear : MonoBehaviour
{
    // Start is called before the first frame update
    private float appearTimer;
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        appearTimer = Random.Range(3,6);
    }

    // Update is called once per frame
    void Update()
    {
        appearTimer -= Time.deltaTime;
        if(appearTimer < 0)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
        }
        if(appearTimer < -3)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            appearTimer = 3;
        }
    }
}
