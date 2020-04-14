using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    private float breakTime;
    private bool breaking;
    private bool broken;
    public Material brokenMat;
    private GameObject currentGameObj;
    void Start()
    {
        breakTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (breaking)
        {
            breakTime -= Time.deltaTime;
        }
        if (breakTime < 0)
        {
            GetComponent<MeshRenderer>().material = brokenMat;
            broken = true;

        }



    }
    private void OnTriggerEnter(Collider other)
    {
        currentGameObj = other.gameObject;
        if (other.gameObject.tag == "Player")
        {
            breaking = true;
        }
        if (broken)
        {
            other.gameObject.transform.position -= Vector3.down * Time.deltaTime * Physics.gravity.y;

            currentGameObj.GetComponent<BoxCollider>().enabled = false;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentGameObj = null;
        if (other.tag == "Player")
        {
            breaking = false;
        }
    }
}
