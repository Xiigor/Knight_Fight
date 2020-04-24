using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lungedBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 400)
        {
            GetComponent<Rigidbody>().AddForce(Target.transform.position * 1000 * Time.deltaTime);
        }
    }
}
