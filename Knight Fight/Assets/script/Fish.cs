using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    private float jumpTimer;
    private Vector3 RandomDir;
    void Start()
    {
        jumpTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer -= Time.deltaTime;
        if(jumpTimer <= 0)
        {
            GetComponent<Rigidbody>().AddForce(Random.Range(-249f, 249f) * 50, 2000 * Time.deltaTime, Random.Range(-249f, 249f) * 50);
            transform.Rotate(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5));
            jumpTimer = 0.5f;
        }
    }
}
