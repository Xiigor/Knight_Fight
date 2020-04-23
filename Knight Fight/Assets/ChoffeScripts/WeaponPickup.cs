using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponPickup : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Rigidbody rb;
    public float throwStrength = 50f;
    public string playerTag = "Player";
    public GameObject parentObject = null;
    public Vector3 Position;
    public Vector3 Rotation;

    private float test = 3f;
    private float test0 = 0f;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(parentObject == null)
        {
            if (test0 <= test)
            {
                test0 += Time.deltaTime;
            }
        }
    }
    public void Throw()
    {
        Debug.Log("wep throw function");
        RemoveParent();
        test0 = 0f;
        //rb.AddForce(parentObject.transform.up * throwStrength);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("trigger");
        if(test0 >= test)
        {
            if (collision.gameObject.tag == playerTag)
            {
                if (parentObject != null)
                {
                    if (collision.gameObject != parentObject)
                    {
                        //Physics.IgnoreCollision(collision.collider, boxCollider);
                    }
                }
                if (parentObject == null)
                {
                    if(collision.gameObject.GetComponent<PlayerStatePattern>().weapon == null)
                    {
                        SetParent(collision.gameObject);
                    }
                }
            }
            else
            {
                transform.parent = null;
            }
        }

    }

    public void SetParent(GameObject parent)
    {
        parentObject = parent;
        parent.gameObject.GetComponent<PlayerStatePattern>().weapon = this.gameObject;
        transform.SetParent(parent.transform.GetChild(0));
        boxCollider.enabled = false;
        rb.useGravity = false;
        rb.isKinematic = true;
        SetPos();
    }
    public void RemoveParent()
    {
        parentObject = null;
        boxCollider.enabled = true;
        rb.useGravity = true;
        rb.isKinematic = false;
    }
    public void SetPos()
    {
        transform.localPosition = Position;
        transform.localEulerAngles = Rotation;
    }
}
