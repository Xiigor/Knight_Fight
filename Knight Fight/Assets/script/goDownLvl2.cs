using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goDownLvl2 : MonoBehaviour
{
    public GameObject ParticleEffectprefab;
    private float randomTimer;
    private float goDownTimer;
    private Vector3 startPos;
    private bool hasStartedParticleSystem;
    private bool hasDropped;
    [SerializeField]
    private bool isMiddle;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        if(isMiddle)
        {
            goDownTimer = 40;
        }
        else if(!isMiddle)
        {
            goDownTimer = 20;
        }
        
        hasDropped = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(goDownTimer);
        goDownTimer -= Time.deltaTime;
        if (goDownTimer < 5 && !hasStartedParticleSystem)
        {
            GameObject particleEffect = Instantiate(ParticleEffectprefab, transform.position + new Vector3(0, 70), Quaternion.identity) as GameObject;
            hasStartedParticleSystem = true;
            Destroy(particleEffect, 5);

        }
        if (goDownTimer <= 0 && goDownTimer > -5)
        {
            transform.Translate(Vector3.down * 100 * Time.deltaTime);
            hasDropped = true;
        }
        if (goDownTimer <= -5)
        {
            if (transform.position.y != startPos.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, 100 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.zero);
            }


        }
        if (transform.position.y == startPos.y && hasDropped)
        {
            if (isMiddle)
            {
                goDownTimer = 40;
            }
            else
            {
                goDownTimer = 30;
            }
            hasDropped = false;
        }
    }
}
