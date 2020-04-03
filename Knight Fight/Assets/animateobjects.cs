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
            for (int i = 0; i < animatedObjects.Length; i++)
            {
                transform.position = Vector3.Lerp(animatedObjects[i].transform.position, animatedObjects[Random.Range(1, count)].transform.position + new Vector3(0,300), 0.1f);
            }
            
            if (moveTimer <= -1f)
            {

                moveTimer = 5;
            }
        }
    }
}
