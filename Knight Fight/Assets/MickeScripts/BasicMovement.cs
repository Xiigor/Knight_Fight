using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;

    private float horizontalMove = 0.0f;
    private float verticalMove = 0.0f;
    [SerializeField] float movementSpeed = 40.0f;
    [SerializeField] [Range(0.0f, 0.3f)] float movementSmoothing = 0.1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * movementSpeed;
        Movement(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
    }

    void Movement(float moveHor, float moveVer)
    {
        Vector3 targetVelocity = new Vector3(moveHor * 12.5f, rb.velocity.y, moveVer * 12.5f);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }
}