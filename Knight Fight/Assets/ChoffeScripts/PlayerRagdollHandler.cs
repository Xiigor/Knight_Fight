using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollHandler : MonoBehaviour
{
    public List<Rigidbody> rigidbodies;
    public GameObject animRig;
    public GameObject ragdollRig;

    public void Awake()
    {
        foreach(Rigidbody index in ragdollRig.GetComponentsInChildren<Rigidbody>())
        {
            rigidbodies.Add(index);
        }
    }

    public void SetRagdollActive()
    {
        animRig.SetActive(false);
        ragdollRig.SetActive(true);
        foreach(Rigidbody index in ragdollRig.GetComponentsInChildren<Rigidbody>())
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
        animRig.SetActive(true);
        ResetRagdollTransforms(animRig, ragdollRig);
        ragdollRig.SetActive(false);
        foreach (Rigidbody index in ragdollRig.GetComponentsInChildren<Rigidbody>())
        {
            index.isKinematic = true;
            index.useGravity = false;
            if (index.GetComponent<Collider>())
            {
                index.GetComponent<Collider>().enabled = false;
            }
        }
    }

    private void ResetRagdollTransforms(GameObject source, GameObject destination)
    {
        for(int i = 0; i < destination.transform.childCount; i++)
        {
            destination.transform.GetChild(i).position = source.transform.GetChild(i).position;
            destination.transform.GetChild(i).rotation = source.transform.GetChild(i).rotation;
        }
    }


}
