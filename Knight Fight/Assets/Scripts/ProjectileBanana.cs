﻿using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBanana : ProjectileBase
{
    // Start is called before the first frame update
    private float internalDespawnTimer = 0f;
    private float despawnTimer = 0f;
    [HideInInspector] public StudioEventEmitter audioPlayer;
    private void Awake()
    {
        flyingState = new ProjectileFlyingState(this);
        groundedState = new ProjectileGroundedState(this);
        rb = GetComponent<Rigidbody>();
        despawnTimer = Random.Range(despawnTimerMin, despawnTimerMax);
        audioPlayer = GetComponent<StudioEventEmitter>();
    }

    private void Start()
    {
        currentState = flyingState;
        LaunchPos(Player);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
        if (internalDespawnTimer >= despawnTimer)
        {
            Destroy(this.gameObject);
        }
        internalDespawnTimer += Time.deltaTime;
    }

    public override void LaunchPos(GameObject parent)
    {

        StateChanger(flyingState);

    }

    public override void StateChanger(ProjectileIState newState)
    {
        currentState = newState;
        currentState.OnStateEnter();
    }

    public override void OnCollisionStay(Collision collision)
    {
        currentState.CollisionStay(collision);
    }
    
    public override void OnCollisionEnter(Collision collision)
    {
        /*currentState.CollisionEnter(collision);

        if (collision.gameObject.tag == playerTag)
        {
            audioPlayer.Play();
        }*/
    }
}

