using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 velocityOnEnter; 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        velocityOnEnter = collision.gameObject.GetComponent<Rigidbody>().velocity;
        collision.gameObject.GetComponent<Rigidbody>().velocity *= 0.01f;

        if(collision.tag == "Player")
        {
            collision.GetComponent<basicmovement>().moveSpeed *= 0.25f;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().velocity = collision.gameObject.GetComponent<Rigidbody>().velocity.normalized * velocityOnEnter.magnitude;
        if (collision.tag == "Player")
        {
            collision.GetComponent<basicmovement>().ResetSpeed();
        }
    }
}
