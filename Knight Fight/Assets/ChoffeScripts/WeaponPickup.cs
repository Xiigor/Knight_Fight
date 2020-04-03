using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Rigidbody rb;

    public Vector3 Position;
    public Vector3 Rotation;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }
    public void SetParent()
    {
        boxCollider.enabled = false;
        rb.useGravity = false;
        rb.isKinematic = true;
    }
    public void RemoveParent()
    {
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
