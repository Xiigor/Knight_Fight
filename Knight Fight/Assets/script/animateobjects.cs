using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateobjects : MonoBehaviour
{
    // Start is called before the first frame update

    private animateobjects[] animatedObjects;
    private Vector3 random;
    private float moveTimer;
    private bool randomPosSet;
    private static int count;
    private int number;
    private int goToSpot;
    private int iRandom;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
        startPos = transform.position;
        animatedObjects = FindObjectsOfType<animateobjects>();
        count++;
        number = count;
        moveTimer = 5;
        goToSpot = number + 1;
        if (number + 1 == animatedObjects.Length)
        {
            goToSpot = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer -= Time.deltaTime;

        if (moveTimer > 0)
        {
            transform.position = Vector3.Lerp(transform.position, startPos, 0.1f); ;
        }
        if (moveTimer <= 0)
        {
            
            transform.position = Vector3.Lerp(transform.position, animatedObjects[goToSpot].transform.position, 0.1f);


            if (moveTimer <= -1f)
            {

                moveTimer = 5;
            }
        }
    }
}
