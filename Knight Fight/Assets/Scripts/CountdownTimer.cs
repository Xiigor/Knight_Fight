using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 5f;

    public bool countdownIsDone = false;
    //public countdownTimer countdownBool;

    [SerializeField]
    Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownIsDone = true;
        }
        //Sätt detta i movement
        //if (countdownBool.countdownIsDone == true)
        //{
        //    Apply movement
        //}
    }
}
