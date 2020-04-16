using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private int playerIndex = 0;

    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;

    private void Awake ()
    {
        //Sets up the controller on Awake
        controller = GetComponent<CharacterController>();
    
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    public void SetInputVector(Vector2 direction)
    {
        //Sets the direction where we want to move
        inputVector = direction;
    }
    // Update is called once per frame
    void Update()
    {
        //Target directions * moveSpeed
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        //Controller moves according to the target direction
        controller.Move(moveDirection * Time.deltaTime);
        
    }
}
