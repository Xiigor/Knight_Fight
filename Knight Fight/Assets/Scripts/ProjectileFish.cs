using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFish : ProjectileBase
{
    
    // Start is called before the first frame update
    private void Awake()
    {
        flyingState = new ProjectileFlyingState(this);
        groundedState = new ProjectileGroundedState(this);
        rb = GetComponent<Rigidbody>();
        
        //spellBook = pa 

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
}
