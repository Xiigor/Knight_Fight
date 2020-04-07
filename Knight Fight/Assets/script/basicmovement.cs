using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicmovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;
    private Vector3 moveDirection;
    [SerializeField]
    private float moveSpeed;
    void Start()
    {
        transform = GetComponent<Transform>();
        moveSpeed = 400;
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }
    void Controls()
    {
        float horizontal = -Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveAngle = new Vector3(0, +0, 45);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
    }
}
