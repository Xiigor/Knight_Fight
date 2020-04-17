using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicmovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform transform;
    private Vector3 moveDirection;
    private float moveSpeed;
    void Start()
    {
        transform = GetComponent<Transform>();
        moveSpeed = 200;
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    //  if (Input.GetAxis("Horizontal") > 0)
    //  {
    //      moveDirection.x = 1;
    //
    //  }
    //
    //  else if (Input.GetAxis("Horizontal") < 0)
    //  {
    //      moveDirection.x = -1;
    //
    //  }
    //  else
    //  {
    //      moveDirection.x = 0;
    //  }
    //  if (Input.GetAxis("Vertical") > 0)
    //  {
    //      moveDirection.z = 1;
    //
    //  }
    //  else if (Input.GetAxis("Vertical") < 0)
    //  {
    //      moveDirection.z = -1;
    //
    //  }
    //  else
    //  {
    //      moveDirection.z = 0;
    //  }
    // //if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
    // //{
    // //    transform.rotation = Quaternion.LookRotation(moveDirection);
    // //}
    //  transform.Translate(moveDirection);

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
