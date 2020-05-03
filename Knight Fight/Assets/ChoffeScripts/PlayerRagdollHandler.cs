using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollHandler : MonoBehaviour
{
    public List<Rigidbody> rigidbodies;

    public void Awake()
    {
        foreach(Rigidbody index in GetComponentsInChildren<Rigidbody>())
        {
            rigidbodies.Add(index);
        }
    }

    public void SetRagdollActive()
    {
        foreach(Rigidbody index in GetComponentsInChildren<Rigidbody>())
        {
            index.isKinematic = false;
            index.useGravity = true;
            if (index.GetComponent<Collider>())
            {
                index.GetComponent<Collider>().enabled = true;
            }
            
        }
        
    }
    public void SetRagdollInactive()
    {
        foreach (Rigidbody index in GetComponentsInChildren<Rigidbody>())
        {
            index.isKinematic = true;
            index.useGravity = false;
            if (index.GetComponent<Collider>())
            {
                index.GetComponent<Collider>().enabled = false;
            }
        }
    }
}
