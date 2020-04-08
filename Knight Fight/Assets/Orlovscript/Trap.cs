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
    private bool onTrap;
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
        if(broken && onTrap)
        {
            currentGameObj.transform.position -= Vector3.down * Time.deltaTime * Physics.gravity.y;
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        currentGameObj = other.gameObject;
        if (other.gameObject.tag == "Player")
        {
            onTrap = true;
            breaking = true;
            Debug.Log("On Trap");
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
            onTrap = false;
            breaking = false;
        }
    }
}
