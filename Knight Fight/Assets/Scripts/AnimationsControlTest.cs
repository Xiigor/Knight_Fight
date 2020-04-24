using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsControlTest : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;

    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.SetBool("Idling", true);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Movement från Unitys hemsida
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        Quaternion turn = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turn);
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            animator.SetBool("Idling", false);
        }
        else
        {
            animator.SetBool("Idling", true);
        }
        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Throwing");
        }
        if (Input.GetKeyDown("q"))
        {
            animator.SetTrigger("Spell Attack");
        }
        if (Input.GetKeyDown("e"))
        {
            animator.SetTrigger("Sword Run");
        }

    }
}
